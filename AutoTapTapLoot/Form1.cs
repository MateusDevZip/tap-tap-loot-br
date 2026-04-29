using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AutoTapTapLoot
{
	public partial class Form1 : Form
	{
		private static class Localization
		{
			public static readonly Dictionary<string, string> PT = new()
			{
				["PacketsPerSecond"]      = "Pacotes Por Segundo",
				["TapsPerPacket"]         = "Taps Por Pacote",
				["AutoTapSettings"]       = "Configurações de Auto Tap",
				["BuffSettings"]          = "Configurações de Amplificadores",
				["ConnectionStatus"]      = "Status de Conexão",
				["TapPipeStatus"]         = "Status do Pipe de Tap",
				["BuffPipeStatus"]        = "Status do Pipe de Amplificador",
				["BuffHint"]              = "O valor é percentual adicionado a cada amplificador (ex. 1 = +100%)",
				["AutoTapLabel"]          = "Auto Tap (Automático)",
				["BuffsLabel"]            = "Amplificadores",
				["EnableAutoTap"]         = "Ativar Auto Tap",
				["DisableAutoTap"]        = "Desativar Auto Tap",
				["ApplyBuffs"]            = "Aplicar Amplificadores",
				["DefaultBuffs"]          = "Restaurar Padrão",
				["StatusUnknown"]         = "Desconhecido",
				["StatusWaiting"]         = "Aguardando...",
				["StatusConnected"]       = "Conectado",
				["StatusDisconnected"]    = "Desconectado",
				["StatusError"]           = "Erro",
				["StatusEnabled"]         = "Ativado",
				["StatusDisabled"]        = "Desativado",
				["StatusApplied"]         = "Aplicado",
				["StatusDefault"]         = "Padrão",
				["ErrLoadSettings"]       = "Falha ao carregar configurações:",
				["ErrTitle"]              = "Erro",
				["WindowTitle"]           = "AutoTapTapLoot - Modificador",
				["Buff_Health"]           = "Vida",
				["Buff_Attack"]           = "Ataque",
				["Buff_Armor"]            = "Armadura",
				["Buff_CritChance"]       = "Chance de Crítico",
				["Buff_Regeneration"]     = "Regeneração",
				["Buff_SpellPower"]       = "Poder Mágico",
				["Buff_Thorns"]           = "Espinhos",
				["Buff_Block"]            = "Bloqueio",
				["Buff_Dodge"]            = "Esquiva",
				["Buff_Slow"]             = "Lentidão",
			};

			public static readonly Dictionary<string, string> EN = new()
			{
				["PacketsPerSecond"]      = "Packets Per Second",
				["TapsPerPacket"]         = "Taps Per Packet",
				["AutoTapSettings"]       = "Auto Tap Settings",
				["BuffSettings"]          = "Buff Settings",
				["ConnectionStatus"]      = "Status",
				["TapPipeStatus"]         = "Tap Pipe Status",
				["BuffPipeStatus"]        = "Buff Pipe Status",
				["BuffHint"]              = "Value is percent added to each buff (ex. 1 = +100%)",
				["AutoTapLabel"]          = "Auto Tap",
				["BuffsLabel"]            = "Buffs",
				["EnableAutoTap"]         = "Enable Auto Tap",
				["DisableAutoTap"]        = "Disable Auto Tap",
				["ApplyBuffs"]            = "Apply Buffs",
				["DefaultBuffs"]          = "Disable Buffs",
				["StatusUnknown"]         = "Unknown",
				["StatusWaiting"]         = "Waiting...",
				["StatusConnected"]       = "Connected",
				["StatusDisconnected"]    = "Disconnected",
				["StatusError"]           = "Error",
				["StatusEnabled"]         = "Enabled",
				["StatusDisabled"]        = "Disabled",
				["StatusApplied"]         = "Applied",
				["StatusDefault"]         = "Default",
				["ErrLoadSettings"]       = "Failed to load settings:",
				["ErrTitle"]              = "Error",
				["WindowTitle"]           = "AutoTapTapLoot - Game Modifier",
				["Buff_Health"]           = "Health",
				["Buff_Attack"]           = "Attack",
				["Buff_Armor"]            = "Armor",
				["Buff_CritChance"]       = "Crit Chance",
				["Buff_Regeneration"]     = "Regeneration",
				["Buff_SpellPower"]       = "Spell Power",
				["Buff_Thorns"]           = "Thorns",
				["Buff_Block"]            = "Block",
				["Buff_Dodge"]            = "Dodge",
				["Buff_Slow"]             = "Slow",
			};
		}
		private static readonly Color DarkBackground = Color.FromArgb(30, 30, 30);
		private static readonly Color DarkControl    = Color.FromArgb(50, 50, 50);

		private static readonly string SettingsPath =
			Path.Combine(AppContext.BaseDirectory, "settings.json");

		private class AppSettings
		{
			public decimal PacketsPerSecond { get; set; } = 15;
			public decimal TapsPerPacket    { get; set; } = 1;
			public Dictionary<string, bool>    BuffChecked { get; set; } = [];
			public Dictionary<string, decimal> BuffValues  { get; set; } = [];
			public string Language { get; set; } = "pt";
		}

		private static readonly string[] BuffKeys =
		{
			"Health", "Attack", "Armor", "CritChance", "Regeneration",
			"SpellPower", "Thorns", "Block", "Dodge", "Slow"
		};

		private readonly Dictionary<string, CheckBox>       _buffChecks = [];
		private readonly Dictionary<string, NumericUpDown>  _buffValues = [];
		private Dictionary<string, string> _strings = Localization.PT;

		private NamedPipeServerStream? _buffPipe;
		private NamedPipeServerStream? _tapPipe;
		private volatile bool _tapEnabled;

		public Form1()
		{
			InitializeComponent();
			BuildBuffTable();
			LoadSettings();
			ApplyLanguage();
			ApplyDarkTheme();

			StartBuffPipeWorker();
			StartTapPipeWorker();
		}

		// ── Configurações ────────────────────────────────────────────────────────

		private void LoadSettings()
		{
			if (!File.Exists(SettingsPath)) return;
			try
			{
				var s = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(SettingsPath));
				if (s == null) return;

				_strings = (s.Language == "en") ? Localization.EN : Localization.PT;
				if (comboBoxLanguage != null)
					comboBoxLanguage.SelectedIndex = (s.Language == "en") ? 1 : 0;

				numericUpDownPacketsPerSecond.Value = Math.Clamp(s.PacketsPerSecond,
					numericUpDownPacketsPerSecond.Minimum, numericUpDownPacketsPerSecond.Maximum);
				numericUpDownTapsPerPacket.Value = Math.Clamp(s.TapsPerPacket,
					numericUpDownTapsPerPacket.Minimum, numericUpDownTapsPerPacket.Maximum);

				foreach (string key in BuffKeys)
				{
					if (s.BuffChecked.TryGetValue(key, out bool chk))
						_buffChecks[key].Checked = chk;
					if (s.BuffValues.TryGetValue(key, out decimal val))
						_buffValues[key].Value = Math.Clamp(val,
							_buffValues[key].Minimum, _buffValues[key].Maximum);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"{_strings["ErrLoadSettings"]}\n{ex.Message}",
					_strings["ErrTitle"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private void SaveSettings()
		{
			var s = new AppSettings
			{
				PacketsPerSecond = numericUpDownPacketsPerSecond.Value,
				TapsPerPacket    = numericUpDownTapsPerPacket.Value,
				BuffChecked      = BuffKeys.ToDictionary(n => n, n => _buffChecks[n].Checked),
				BuffValues       = BuffKeys.ToDictionary(n => n, n => _buffValues[n].Value),
				Language         = (comboBoxLanguage?.SelectedIndex == 1) ? "en" : "pt",
			};
			File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(s, Formatting.Indented));
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			SaveSettings();
			base.OnFormClosing(e);
		}

		// ── UI de Amplificadores ─────────────────────────────────────────────────

		private void BuildBuffTable()
		{
			labelStatusBuff.Text     = _strings["StatusUnknown"];
			labelStatusBuff.ForeColor = Color.Gray;

			tableLayoutPanelBuffs.AutoSize  = true;
			tableLayoutPanelBuffs.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
			tableLayoutPanelBuffs.SuspendLayout();
			tableLayoutPanelBuffs.RowCount = BuffKeys.Length;
			tableLayoutPanelBuffs.Controls.Clear();

			for (int i = 0; i < BuffKeys.Length; i++)
			{
				string key = BuffKeys[i];
				string displayName = _strings[$"Buff_{key}"];

				var chk = new CheckBox {
					Checked = true,
					AutoSize = true
				};
				var lbl = new Label {
					Text = displayName,
					AutoSize = true,
					ForeColor = Color.White
				};
				var num = new NumericUpDown {
					Minimum       = -10_000_000,
					Maximum       = 10_000_000,
					DecimalPlaces = 2,
					Value         = (key != "Slow") ? 1 : -1,
					Width         = 120
				};

				_buffChecks[key] = chk;
				_buffValues[key] = num;

				tableLayoutPanelBuffs.Controls.Add(chk, 0, i);
				tableLayoutPanelBuffs.Controls.Add(lbl, 1, i);
				tableLayoutPanelBuffs.Controls.Add(num, 2, i);
			}

			tableLayoutPanelBuffs.ResumeLayout();
		}

		// ── Tema ───────────────────────────────────────────────────────────────

		private void ApplyDarkTheme()
		{
			BackColor = DarkBackground;
			ForeColor = Color.White;
			ApplyThemeToControls(Controls);
		}

		private void ApplyLanguage()
		{
			_strings = (comboBoxLanguage?.SelectedIndex == 1) ? Localization.EN : Localization.PT;

			Text = _strings["WindowTitle"];
			label1.Text = _strings["PacketsPerSecond"];
			label2.Text = _strings["TapsPerPacket"];
			groupBox1.Text = _strings["AutoTapSettings"];
			groupBox2.Text = _strings["BuffSettings"];
			label3.Text = _strings["BuffHint"];
			buttonAutoTapEnable.Text = _strings["EnableAutoTap"];
			buttonAutoTapDisable.Text = _strings["DisableAutoTap"];
			buttonBuffsApply.Text = _strings["ApplyBuffs"];
			buttonBuffsDefault.Text = _strings["DefaultBuffs"];
			groupBox3.Text = _strings["ConnectionStatus"];
			label4.Text = _strings["TapPipeStatus"];
			label5.Text = _strings["AutoTapLabel"];
			label6.Text = _strings["BuffPipeStatus"];
			label7.Text = _strings["BuffsLabel"];

			BuildBuffTable();

			SaveSettings();
		}

		private void ApplyThemeToControls(Control.ControlCollection controls)
		{
			foreach (Control c in controls)
			{
				switch (c)
				{
					case Button btn:
						btn.BackColor = DarkControl;
						btn.ForeColor = Color.White;
						btn.FlatStyle = FlatStyle.Flat;
						btn.FlatAppearance.BorderColor = Color.Gray;
						break;
					case CheckBox cb:
						cb.ForeColor = Color.White;
						cb.BackColor = DarkBackground;
						break;
					case NumericUpDown num:
						num.BackColor = DarkControl;
						num.ForeColor = Color.White;
						break;
					case TextBox tb:
						tb.BackColor = DarkControl;
						tb.ForeColor = Color.White;
						tb.BorderStyle = BorderStyle.FixedSingle;
						break;
					case GroupBox gb:
						gb.ForeColor = Color.White;
						gb.BackColor = DarkBackground;
						break;
				}

				if (c.HasChildren)
					ApplyThemeToControls(c.Controls);
			}
		}

		// ── Funções Auxiliares ────────────────────────────────────────────────────

		private static void SetLabelStatus(Label label, string text, Color color)
		{
			if (label.InvokeRequired)
			{
				label.Invoke(() => SetLabelStatus(label, text, color));
				return;
			}
			label.Text      = text;
			label.ForeColor = color;
		}

		private static void SendString(NamedPipeServerStream? pipe, string msg)
		{
			if (pipe == null || !pipe.IsConnected)
				return;

			byte[] data   = Encoding.Unicode.GetBytes(msg);
			ushort len    = (ushort)data.Length;
			byte[] prefix = [(byte)(len >> 8), (byte)(len & 0xFF)];

			pipe.Write(prefix, 0, 2);
			pipe.Write(data, 0, data.Length);
			pipe.Flush();
		}

		// ── Pipes ──────────────────────────────────────────────────────────────

		private void StartTapPipeWorker()
		{
			SetLabelStatus(labelStatusTap, _strings["StatusDisabled"], Color.Red);

			var thread = new Thread(() =>
			{
				while (true)
				{
					try
					{
						SetLabelStatus(labelStatusPipeTap, _strings["StatusWaiting"], Color.Orange);

						_tapPipe = new NamedPipeServerStream(
							"TapTapLootxTheFarmerWasReplaced",
							PipeDirection.InOut, 1,
							PipeTransmissionMode.Byte, PipeOptions.None);

						_tapPipe.WaitForConnection();
						SetLabelStatus(labelStatusPipeTap, _strings["StatusConnected"], Color.Lime);

						while (_tapPipe.IsConnected)
						{
							if (!_tapEnabled)
							{
								Thread.Sleep(50);
								continue;
							}

							int pps = Math.Max(1, (int)numericUpDownPacketsPerSecond.Value);
							SendString(_tapPipe, ((int)numericUpDownTapsPerPacket.Value).ToString());
							Thread.Sleep(1000 / pps);
						}

						SetLabelStatus(labelStatusPipeTap, _strings["StatusDisconnected"], Color.Red);
					}
					catch
					{
						SetLabelStatus(labelStatusPipeTap, _strings["StatusError"], Color.Red);
					}
					finally
					{
						_tapPipe?.Dispose();
						_tapPipe = null;
					}

					Thread.Sleep(1000);
				}
			}) { IsBackground = true };

			thread.Start();
		}

		private void StartBuffPipeWorker()
		{
			var thread = new Thread(() =>
			{
				while (true)
				{
					try
					{
						SetLabelStatus(labelStatusPipeBuff, _strings["StatusWaiting"], Color.Orange);

						_buffPipe = new NamedPipeServerStream(
							"TapTapLootxBongoCat",
							PipeDirection.InOut, 1,
							PipeTransmissionMode.Byte, PipeOptions.None);

						_buffPipe.WaitForConnection();
						SetLabelStatus(labelStatusPipeBuff, _strings["StatusConnected"], Color.Lime);

						while (_buffPipe.IsConnected)
							Thread.Sleep(100);

						SetLabelStatus(labelStatusPipeBuff, _strings["StatusDisconnected"], Color.Red);
					}
					catch
					{
						SetLabelStatus(labelStatusPipeBuff, _strings["StatusError"], Color.Red);
					}
					finally
					{
						_buffPipe?.Dispose();
						_buffPipe = null;
					}

					Thread.Sleep(1000);
				}
			}) { IsBackground = true };

			thread.Start();
		}

		// ── Manipuladores de Botão ────────────────────────────────────────────

		private void buttonBuffsApply_Click(object sender, EventArgs e)
		{
			SetLabelStatus(labelStatusBuff, _strings["StatusApplied"], Color.Lime);

			var buffs = new List<object>();
			foreach (string key in BuffKeys)
			{
				if (!_buffChecks[key].Checked) continue;
				buffs.Add(new { Name = key, Value = (float)_buffValues[key].Value });
			}

			SendString(_buffPipe, JsonConvert.SerializeObject(buffs));
		}

		private void buttonBuffsDefault_Click(object sender, EventArgs e)
		{
			SetLabelStatus(labelStatusBuff, _strings["StatusDefault"], Color.White);

			var buffs = new List<object>();
			foreach (string key in BuffKeys)
				buffs.Add(new { Name = key, Value = 0f });

			SendString(_buffPipe, JsonConvert.SerializeObject(buffs));
		}

		private void buttonAutoTapEnable_Click(object sender, EventArgs e)
		{
			SetLabelStatus(labelStatusTap, _strings["StatusEnabled"], Color.Lime);
			_tapEnabled = true;
		}

		private void buttonAutoTapDisable_Click(object sender, EventArgs e)
		{
			SetLabelStatus(labelStatusTap, _strings["StatusDisabled"], Color.Red);
			_tapEnabled = false;
		}

		private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyLanguage();
		}

	}
}
