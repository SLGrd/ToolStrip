using System;
using System.Drawing;
using System.Windows.Forms;
using ToolBar.Properties;

namespace ToolBar
{
    public partial class FrmToolStrip : Form
    {
        ToolStripTextBox     tsbArgmto;
        ToolStripComboBox    tscFields;
        ToolStripProgressBar tstProgress;

        readonly Timer tmr = new Timer();

        public FrmToolStrip()
        {
            InitializeComponent();
            TollStripConfiguration();

            //  Set timer event handler
            tmr.Tick += Tmr_Tick;
        }

        private void TollStripConfiguration()
        {
            // Create a new ToolStrip control.
            ToolStrip tlsAction = new ToolStrip
            {
                Dock = DockStyle.Top,   
                BackColor= Color.Silver
            };                                         
            this.Controls.Add( tlsAction);           // Add the ToolStrip control to the Controls collection.

            tlsAction.Items.Clear();
            
            ToolStripButton tstNewRecord = new ToolStripButton() {  //  Instancia o componente
                Image = Resources.newRecord32,                      //  Usamos as propriedades para configurar
                ToolTipText = "Add new record",                     //
            };
            tstNewRecord.Click += TstNewRecord_Click;               //  Informamos o nome da rotina que vai tratar o evento
            tlsAction.Items.Add( tstNewRecord);                     //  Adicionamos na barra de ferramentes

            ToolStripButton tstRefresh = new ToolStripButton {                
                Image = Resources.undo32,
                ToolTipText = "Restore current record"
            };
            tstRefresh.Click += TstRefresh_Click;
            tlsAction.Items.Add( tstRefresh);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 6 });

            ToolStripButton tstDelete = new ToolStripButton {                
                Image = Resources.delete32,
                ToolTipText = "Delete current record"
            };
            tstDelete.Click += TstDelete_Click;
            tlsAction.Items.Add( tstDelete);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Height = 32, Width = 12 });

            ToolStripLabel tslSearch = new ToolStripLabel {
                Font = new Font("Arial", 11),
                Text = "Search"
            };
            tlsAction.Items.Add( tslSearch);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 6 });

            tsbArgmto = new ToolStripTextBox {
                Font = new Font("Arial", 11),
                MaxLength = 24,
                BorderStyle = BorderStyle.FixedSingle
            };
            tlsAction.Items.Add( tsbArgmto);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 6 });

            tscFields = new ToolStripComboBox
            {
                FlatStyle = FlatStyle.System,                                               //  Estilo da combo. Vc pode tentar outros 
            };
            tscFields.Items.AddRange(new string[] { "Nome", "Endereco", "Funcao" });        // Monta a lisra de opções
            tlsAction.Items.Add( tscFields);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 6 });

            ToolStripButton tstFind = new ToolStripButton {
                Image = Resources.search32,
                ToolTipText = "Add new record"
            };
            tstFind.Click += TstFind_Click;
            tlsAction.Items.Add (tstFind);

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 12 });

            //  ------------------------------Drop Down Button (DDB) - Inicio ------------------------------------------------------
            //  Vamos incluir um drop down button com uma lista de de duas opcoes por exemplo:
            //
            //      DropDownButtom
            //            |-----------> Drop Opcao "A"  
            //            |-----------> Drop Opcao "B" 
            //
            //  Para definir um drop down button (DDB) como neste no exemplo abaixo recomendo o seguinte:
            //
            //  1.  Definir is itens de menu 'Opcao "A" ' e 'Opcao "B" '   ----->   (linhas comentadas //** opcao A e //** opcao B)
            //
            //  2.  Definir o drop down button que vai conter as duas opcoes --->   (linha comentada   //* Instancia o Drop Down Button
            //
            //  3.  Adiciona os itens de menu a collection de DropDownItems do DDB  (linha comentada   //* Add to Button collection
            //
            //  4.  Finalmente adiciona o DropDownButton a ToolStrip controls collection ( linha       //* Add DDB to ToolStrip  
            //

            ToolStripMenuItem tstDropMnuItemOptionA = new ToolStripMenuItem     //* opcao A 
            {
                Image = Resources.check32,
                Text = "OptionDrop A"
            };
            tstDropMnuItemOptionA.Click += TstDropMnuItemOption_Click;          //  Define qual a funcao que vai tratar o evento CLICK

            ToolStripMenuItem tstDropMnuItemOptionB = new ToolStripMenuItem     //* opcao B
            {
                Image = Resources.delete32,
                Text = "OptionDrop B"
            };
            tstDropMnuItemOptionB.Click += TstDropMnuItemOption_Click;          //  Define qual a funcao que vai tratar o evento CLICK

            ToolStripDropDownButton tstDropBtn = new ToolStripDropDownButton    //* Instancia o Drop Down Button
            { 
                Image = Resources.newRecord32,               
                BackColor = Color.Silver,
                Text = "Drop"                 
            };
            tstDropBtn.Click += TstDropBtn_Click;
            tstDropBtn.DropDownItems.Add(tstDropMnuItemOptionA);                   //* Add to DropDownItems collection
            tstDropBtn.DropDownItems.Add(tstDropMnuItemOptionB);                   //* Add to DropDownItems collection
            tlsAction.Items.Add( tstDropBtn);                                      //* Add DDB to ToolStrip  

            // ---------------------------------Drop Down Button (DDB) - final --------------------------------------------------------
            
            // -------------------------------- Split Button ( SpltBt) - Inicio  ------------------------------------------------------

            ToolStripMenuItem tstSplitMnuItemOptionA = new ToolStripMenuItem     
            {
                Image = Resources.check32,
                Text = "OptionSplit A"
            };
            tstSplitMnuItemOptionA.Click += TstDropMnuItemOption_Click;          

            ToolStripMenuItem tstSplitMnuItemOptionB = new ToolStripMenuItem     
            {
                Image = Resources.delete32,
                Text = "OptionSplit B"
            };
            tstSplitMnuItemOptionB.Click += TstDropMnuItemOption_Click;          

            ToolStripSplitButton tstSplitBtn = new ToolStripSplitButton      
            {
                Image = Resources.newRecord32,
                ForeColor = Color.Green,
                Text      = "Split"
            };
            tstSplitBtn.Click += TstSplitBtn_Click;
            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionA);                   
            tstSplitBtn.DropDownItems.Add(tstSplitMnuItemOptionB);                   
            tlsAction.Items.Add( tstSplitBtn);

            // -------------------------------- Split Button ( SpltBt) - Final  ------------------------------------------------------

            tlsAction.Items.Add(new ToolStripSeparator { AutoSize = false, Width = 12 });

            tstProgress = new ToolStripProgressBar
            {                
                AutoSize = false,               
                Width  = 400,
                Height = 12,
                Value = 100
            };
            tlsAction.Items.Add( tstProgress);          
        }

        private void TstDropMnuItemOption_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m = (ToolStripMenuItem)sender;            
            txtInfoBox.Text += $"{DateTime.Now.ToString("dd/MM HH:mm:ss") } Option : { m.Text } \r\n" ;
        }

        private void TstDropBtn_Click(object sender, EventArgs e)
        {
            ToolStripDropDownButton d = (ToolStripDropDownButton)sender;             
            txtInfoBox.Text += $"{DateTime.Now.ToString("dd/MM HH:mm:ss") } Option : { d.Text } \r\n";
        }

        private void TstSplitBtn_Click(object sender, EventArgs e)
        {
            ToolStripSplitButton s = (ToolStripSplitButton)sender;
            txtInfoBox.Text += $"{DateTime.Now.ToString("dd/MM HH:mm:ss") } Option : { s.Text } \r\n";
        }

        private void TstNewRecord_Click(object sender, EventArgs e)
        {
            //  Sinaliza click no botao
            txtInfoBox.Text += $"{ DateTime.Now.ToString("dd/MM HH:mm:ss")} New record button clicked \r\n";

            //  Reset progress bar properties
            tstProgress.Minimum = 0;
            tstProgress.Maximum = 100;
            tstProgress.Value = 0;

            // Set timer with a 1 second interval.
            tmr.Interval = 300;  // 0.3 seconds = 300 miliseconds
            tmr.Enabled = true;  // Start timer
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            //  Timer set to execute this function every 0.3 second ( 300 miliseconds)
            if (tstProgress.Value < 100) 
            {
                tstProgress.Value++;
            }
            else
            {
                tmr.Enabled = false;
            }
        }

        private void TstSave_Click(object sender, EventArgs e)
        {
            //  Sinaliza click no botao
            txtInfoBox.Text += $"{ DateTime.Now.ToString("dd/MM HH:mm:ss")} Save button clicked \r\n";
        }

        private void TstRefresh_Click(object sender, EventArgs e)
        {
            //  Sinaliza click no botao
            txtInfoBox.Text += $"{ DateTime.Now.ToString("dd/MM HH:mm:ss")} Refresh button clicked \r\n";
        }

        private void TstDelete_Click(object sender, EventArgs e)
        {
            //  Sinaliza click no botao
            txtInfoBox.Text += $"{ DateTime.Now.ToString("dd/MM HH:mm:ss")} Delete button clicked \r\n";
        }

        private void TstFind_Click(object sender, EventArgs e)
        {
            //  Sinaliza click no botao
            txtInfoBox.Text += $"{ DateTime.Now.ToString("dd/MM HH:mm:ss")} Find button clicked ==> ";
            //  Monta um exemplo de comando SQL
            txtInfoBox.Text += $"Select * from Clientes where { tscFields.Text} contains '{ tsbArgmto.Text}' \r\n";
        }

        private void TxtInfoBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtInfoBox.Clear();
        }
    }
}