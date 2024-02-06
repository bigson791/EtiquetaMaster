namespace EtiquetaMaster
{
    partial class ReporteVidrios
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVidrios));
            this.tbVidriosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblNumOrden = new System.Windows.Forms.Label();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.vidriosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vidriosDataSet = new EtiquetaMaster.VidriosDataSet();
            this.tbVidriosTableAdapter = new EtiquetaMaster.VidriosDataSetTableAdapters.tbVidriosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbVidriosBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vidriosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidriosDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbVidriosBindingSource
            // 
            this.tbVidriosBindingSource.DataMember = "tbVidrios";
            this.tbVidriosBindingSource.DataSource = this.vidriosDataSetBindingSource;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbVidriosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EtiquetaMaster.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 426);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // lblNumOrden
            // 
            this.lblNumOrden.AutoSize = true;
            this.lblNumOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNumOrden.Location = new System.Drawing.Point(12, 1);
            this.lblNumOrden.Name = "lblNumOrden";
            this.lblNumOrden.Size = new System.Drawing.Size(139, 20);
            this.lblNumOrden.TabIndex = 2;
            this.lblNumOrden.Text = "Ingresa No. Orden";
            this.lblNumOrden.Click += new System.EventHandler(this.lblRuta_Click);
            // 
            // txtNumOrden
            // 
            this.txtNumOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOrden.Location = new System.Drawing.Point(157, 1);
            this.txtNumOrden.Name = "txtNumOrden";
            this.txtNumOrden.Size = new System.Drawing.Size(177, 22);
            this.txtNumOrden.TabIndex = 3;
            this.txtNumOrden.TextChanged += new System.EventHandler(this.txtNumOrden_TextChanged);
            this.txtNumOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOrden_KeyPress);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Location = new System.Drawing.Point(340, 0);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(86, 22);
            this.btnEjecutar.TabIndex = 4;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // vidriosDataSetBindingSource
            // 
            this.vidriosDataSetBindingSource.DataSource = this.vidriosDataSet;
            this.vidriosDataSetBindingSource.Position = 0;
            // 
            // vidriosDataSet
            // 
            this.vidriosDataSet.DataSetName = "VidriosDataSet";
            this.vidriosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbVidriosTableAdapter
            // 
            this.tbVidriosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteVidrios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtNumOrden);
            this.Controls.Add(this.lblNumOrden);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReporteVidrios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vidrios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FORM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbVidriosBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vidriosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidriosDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private VidriosDataSet vidriosDataSet;
        private System.Windows.Forms.BindingSource vidriosDataSetBindingSource;
        private System.Windows.Forms.BindingSource tbVidriosBindingSource;
        private VidriosDataSetTableAdapters.tbVidriosTableAdapter tbVidriosTableAdapter;
        private System.Windows.Forms.Label lblNumOrden;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.Button btnEjecutar;
    }
}