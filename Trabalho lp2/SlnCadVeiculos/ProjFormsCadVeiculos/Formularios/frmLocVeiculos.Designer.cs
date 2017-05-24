namespace ProjFormsCadVeiculos.Formularios
{
    partial class frmLocVeiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocVeiculos));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttbDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao,
            this.cliente,
            this.modelo,
            this.valor,
            this.datacadastro,
            this.datavenda,
            this.observacoes,
            this.ativo});
            this.dgv.Location = new System.Drawing.Point(26, 95);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(737, 252);
            this.dgv.TabIndex = 9;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "descricao";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 202;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "ncliente";
            this.cliente.HeaderText = "cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // modelo
            // 
            this.modelo.DataPropertyName = "nmodelo";
            this.modelo.HeaderText = "modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor";
            this.valor.HeaderText = "valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // datacadastro
            // 
            this.datacadastro.DataPropertyName = "datacadastro";
            this.datacadastro.HeaderText = "datacadastro";
            this.datacadastro.Name = "datacadastro";
            this.datacadastro.ReadOnly = true;
            // 
            // datavenda
            // 
            this.datavenda.DataPropertyName = "datavenda";
            this.datavenda.HeaderText = "datavenda";
            this.datavenda.Name = "datavenda";
            this.datavenda.ReadOnly = true;
            // 
            // observacoes
            // 
            this.observacoes.DataPropertyName = "observacoes";
            this.observacoes.HeaderText = "observacoes";
            this.observacoes.Name = "observacoes";
            this.observacoes.ReadOnly = true;
            // 
            // ativo
            // 
            this.ativo.DataPropertyName = "ativo";
            this.ativo.HeaderText = "ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            // 
            // ttbDescricao
            // 
            this.ttbDescricao.Location = new System.Drawing.Point(26, 50);
            this.ttbDescricao.MaxLength = 100;
            this.ttbDescricao.Multiline = true;
            this.ttbDescricao.Name = "ttbDescricao";
            this.ttbDescricao.Size = new System.Drawing.Size(438, 27);
            this.ttbDescricao.TabIndex = 8;
            this.ttbDescricao.TextChanged += new System.EventHandler(this.ttbDescricao_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Descricao";
            // 
            // frmLocVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.ttbDescricao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Veiculos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox ttbDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}