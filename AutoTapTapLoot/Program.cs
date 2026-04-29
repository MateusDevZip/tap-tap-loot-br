namespace AutoTapTapLoot
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal da aplicação.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para personalizar a configuração da aplicação, como definir configurações de DPI alta ou fonte padrão,
            // veja https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}