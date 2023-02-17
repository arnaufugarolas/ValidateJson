namespace ValidateJson
{
    partial class UiScreen
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_importData = new System.Windows.Forms.Button();
            this.tb_pathFile = new System.Windows.Forms.TextBox();
            this.cb_eliminacio = new System.Windows.Forms.ComboBox();
            this.btn_filterData = new System.Windows.Forms.Button();
            this.cb_modoUso = new System.Windows.Forms.ComboBox();
            this.tb_linq = new System.Windows.Forms.TextBox();
            this.tb_seq = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_num_invalidas = new System.Windows.Forms.Label();
            this.label_num_validas = new System.Windows.Forms.Label();
            this.label_total_personas = new System.Windows.Forms.Label();
            this.dgrid_datos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_importData
            // 
            this.btn_importData.Location = new System.Drawing.Point(970, 38);
            this.btn_importData.Margin = new System.Windows.Forms.Padding(2);
            this.btn_importData.Name = "btn_importData";
            this.btn_importData.Size = new System.Drawing.Size(213, 31);
            this.btn_importData.TabIndex = 2;
            this.btn_importData.Text = "Import File (.JSON)";
            this.btn_importData.UseVisualStyleBackColor = true;
            this.btn_importData.Click += new System.EventHandler(this.ButtonInsertDataFromFile);
            // 
            // tb_pathFile
            // 
            this.tb_pathFile.Location = new System.Drawing.Point(969, 11);
            this.tb_pathFile.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pathFile.Name = "tb_pathFile";
            this.tb_pathFile.Size = new System.Drawing.Size(214, 23);
            this.tb_pathFile.TabIndex = 4;
            // 
            // cb_eliminacio
            // 
            this.cb_eliminacio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_eliminacio.FormattingEnabled = true;
            this.cb_eliminacio.Items.AddRange(new object[] {
            "DELETE VALID",
            "DELETE INVALID"});
            this.cb_eliminacio.Location = new System.Drawing.Point(969, 100);
            this.cb_eliminacio.Margin = new System.Windows.Forms.Padding(2);
            this.cb_eliminacio.Name = "cb_eliminacio";
            this.cb_eliminacio.Size = new System.Drawing.Size(214, 23);
            this.cb_eliminacio.TabIndex = 8;
            // 
            // btn_filterData
            // 
            this.btn_filterData.Location = new System.Drawing.Point(970, 127);
            this.btn_filterData.Margin = new System.Windows.Forms.Padding(2);
            this.btn_filterData.Name = "btn_filterData";
            this.btn_filterData.Size = new System.Drawing.Size(213, 30);
            this.btn_filterData.TabIndex = 6;
            this.btn_filterData.Text = "Filter Data";
            this.btn_filterData.UseVisualStyleBackColor = true;
            this.btn_filterData.Click += new System.EventHandler(this.ButtonFilterDataFromFilter);
            // 
            // cb_modoUso
            // 
            this.cb_modoUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_modoUso.FormattingEnabled = true;
            this.cb_modoUso.Items.AddRange(new object[] {
            "PARALLEL LINQ",
            "SEQUENCIAL"});
            this.cb_modoUso.Location = new System.Drawing.Point(969, 73);
            this.cb_modoUso.Margin = new System.Windows.Forms.Padding(2);
            this.cb_modoUso.Name = "cb_modoUso";
            this.cb_modoUso.Size = new System.Drawing.Size(214, 23);
            this.cb_modoUso.TabIndex = 5;
            // 
            // tb_linq
            // 
            this.tb_linq.Location = new System.Drawing.Point(607, 324);
            this.tb_linq.Margin = new System.Windows.Forms.Padding(2);
            this.tb_linq.Name = "tb_linq";
            this.tb_linq.Size = new System.Drawing.Size(210, 23);
            this.tb_linq.TabIndex = 18;
            // 
            // tb_seq
            // 
            this.tb_seq.Location = new System.Drawing.Point(606, 283);
            this.tb_seq.Margin = new System.Windows.Forms.Padding(2);
            this.tb_seq.Name = "tb_seq";
            this.tb_seq.Size = new System.Drawing.Size(210, 23);
            this.tb_seq.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(519, 324);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Parallel Linq";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(519, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sequencial:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(11, 284);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Num People:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(11, 304);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Valid persons:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(11, 324);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Invalid Persons:";
            // 
            // label_num_invalidas
            // 
            this.label_num_invalidas.AutoSize = true;
            this.label_num_invalidas.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_num_invalidas.Location = new System.Drawing.Point(128, 324);
            this.label_num_invalidas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_num_invalidas.Name = "label_num_invalidas";
            this.label_num_invalidas.Size = new System.Drawing.Size(31, 20);
            this.label_num_invalidas.TabIndex = 21;
            this.label_num_invalidas.Text = "0/0";
            // 
            // label_num_validas
            // 
            this.label_num_validas.AutoSize = true;
            this.label_num_validas.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_num_validas.Location = new System.Drawing.Point(117, 304);
            this.label_num_validas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_num_validas.Name = "label_num_validas";
            this.label_num_validas.Size = new System.Drawing.Size(31, 20);
            this.label_num_validas.TabIndex = 22;
            this.label_num_validas.Text = "0/0";
            // 
            // label_total_personas
            // 
            this.label_total_personas.AutoSize = true;
            this.label_total_personas.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_total_personas.Location = new System.Drawing.Point(111, 284);
            this.label_total_personas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_total_personas.Name = "label_total_personas";
            this.label_total_personas.Size = new System.Drawing.Size(17, 20);
            this.label_total_personas.TabIndex = 23;
            this.label_total_personas.Text = "0";
            // 
            // dgrid_datos
            // 
            this.dgrid_datos.AllowUserToAddRows = false;
            this.dgrid_datos.AllowUserToDeleteRows = false;
            this.dgrid_datos.AllowUserToOrderColumns = true;
            this.dgrid_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrid_datos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrid_datos.BackgroundColor = System.Drawing.Color.White;
            this.dgrid_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_datos.GridColor = System.Drawing.Color.White;
            this.dgrid_datos.Location = new System.Drawing.Point(11, 11);
            this.dgrid_datos.Margin = new System.Windows.Forms.Padding(2);
            this.dgrid_datos.Name = "dgrid_datos";
            this.dgrid_datos.RowHeadersWidth = 51;
            this.dgrid_datos.RowTemplate.Height = 24;
            this.dgrid_datos.ShowCellErrors = false;
            this.dgrid_datos.ShowCellToolTips = false;
            this.dgrid_datos.ShowEditingIcon = false;
            this.dgrid_datos.Size = new System.Drawing.Size(954, 258);
            this.dgrid_datos.TabIndex = 6;
            this.dgrid_datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_datos_CellContentClick);
            // 
            // UiScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 359);
            this.Controls.Add(this.cb_eliminacio);
            this.Controls.Add(this.btn_filterData);
            this.Controls.Add(this.tb_linq);
            this.Controls.Add(this.tb_pathFile);
            this.Controls.Add(this.tb_seq);
            this.Controls.Add(this.label_total_personas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_importData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_modoUso);
            this.Controls.Add(this.label_num_validas);
            this.Controls.Add(this.label_num_invalidas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgrid_datos);
            this.Controls.Add(this.label10);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UiScreen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validate JSON";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_importData;
        private System.Windows.Forms.Button btn_filterData;
        private System.Windows.Forms.ComboBox cb_modoUso;
        private System.Windows.Forms.TextBox tb_pathFile;
        private System.Windows.Forms.ComboBox cb_eliminacio;
        private System.Windows.Forms.TextBox tb_linq;
        private System.Windows.Forms.TextBox tb_seq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label_num_invalidas;
        private Label label_num_validas;
        private Label label_total_personas;
        private DataGridView dgrid_datos;
    }
}

