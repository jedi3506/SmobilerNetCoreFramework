using Smobiler.Core;

namespace SmobilerApplication1
{
    partial class SmobilerForm1 : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm Designer generated code "

        //SmobilerForm overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerForm Designer
        //It can be modified using the SmobilerForm Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.button1 = new Smobiler.Core.Controls.Button();
            this.button2 = new Smobiler.Core.Controls.Button();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 38);
            this.button1.Text = "button1";
            this.button1.Press += new System.EventHandler(this.button1_Press);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 35);
            this.button2.Text = "button2";
            this.button2.Press += new System.EventHandler(this.button2_Press);
            // 
            // SmobilerForm1
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.button1,
            this.button2});
            this.Name = "SmobilerForm1";

        }
        #endregion

        private Smobiler.Core.Controls.Button button1;
        private Smobiler.Core.Controls.Button button2;
    }
}