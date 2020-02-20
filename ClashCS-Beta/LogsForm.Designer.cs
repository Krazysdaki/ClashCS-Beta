namespace ClashCS
{
    partial class LogsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsForm));
            this.SuspendLayout();
            // 
            // LogsForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ResumeLayout(false);

        }

        private void DrawLogsForm()
        {
            ClashCS.LogsForm.listView1 = new System.Windows.Forms.ListView();
            ClashCS.LogsForm.LogLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ClashCS.LogsForm.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ClashCS.LogsForm.Payload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            ClashCS.LogsForm.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ClashCS.LogsForm.LogLevel,
            ClashCS.LogsForm.Time,
            ClashCS.LogsForm.Payload});
            ClashCS.LogsForm.listView1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            ClashCS.LogsForm.listView1.GridLines = true;
            ClashCS.LogsForm.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            ClashCS.LogsForm.listView1.HoverSelection = true;
            ClashCS.LogsForm.listView1.Location = new System.Drawing.Point(12, 12);
            ClashCS.LogsForm.listView1.Name = "listView1";
            ClashCS.LogsForm.listView1.Size = new System.Drawing.Size(850, 400);
            ClashCS.LogsForm.listView1.TabIndex = 0;
            ClashCS.LogsForm.listView1.UseCompatibleStateImageBehavior = false;
            ClashCS.LogsForm.listView1.View = System.Windows.Forms.View.Details;
            // 
            // LogLevel
            // 
            ClashCS.LogsForm.LogLevel.Text = "Log Level";
            ClashCS.LogsForm.LogLevel.Width = 90;
            // 
            // Time
            // 
            ClashCS.LogsForm.Time.Text = "Time";
            ClashCS.LogsForm.Time.Width = 80;
            // 
            // Payload
            // 
            ClashCS.LogsForm.Payload.Text = "Payload";
            ClashCS.LogsForm.Payload.Width = 650;

            this.ClientSize = new System.Drawing.Size(875, 425);
            this.Name = "LogsForm";
            this.Text = "Logs";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogsForm_FormClosing);
            this.ResumeLayout(false);
            this.Controls.Add(listView1);
        }

        public static System.Windows.Forms.ColumnHeader LogLevel;
        public static System.Windows.Forms.ColumnHeader Time;
        public static System.Windows.Forms.ColumnHeader Payload;
        public static System.Windows.Forms.ListView listView1;
    }
}

