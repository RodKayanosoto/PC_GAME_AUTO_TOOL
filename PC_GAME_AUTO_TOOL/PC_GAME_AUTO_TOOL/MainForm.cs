using PC_GAME_AUTO_TOOL.Functions.Macro.MacroForGames.Elona;

namespace PC_GAME_AUTO_TOOL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            BlackCatReload.DoMacro();
        }
    }
}
