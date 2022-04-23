using System.Data.SqlClient;
using System.Data;


namespace Pedidos
{
    public partial class Form1 : Form
    {
        SqlConnection conexao = new SqlConnection("Server=database2.caktimjcdoua.sa-east-1.rds.amazonaws.com;Database=trabalhoFinalDataBase;User Id=admin;Password=SenhaAdmin;");
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strSQL;
        
        public Form1()
        {
            InitializeComponent();

            try
            {

                strSQL = "Select * FROM dbo.Pedidos";

                comando = new SqlCommand(strSQL, conexao);

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                GridDados.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_atualizar_Click(object sender, EventArgs e)
        {
            try
            {
               
                strSQL = "Select * FROM dbo.Pedidos";

                comando = new SqlCommand(strSQL, conexao);

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL,conexao);

                conexao.Open();

                da.Fill(ds);

                GridDados.DataSource = ds.Tables[0];
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }


            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_inserir_Click(object sender, EventArgs e)
        {
            try
            {
                strSQL = "INSERT INTO Pedidos (nomeCliente,statusPedido,itensPedido) VALUES (@Nome,'Não Pago',@Pedido)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@Nome",txt_cliente.Text);
                comando.Parameters.AddWithValue("@Pedido", txt_pedido.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            try
            {
                strSQL = "Select * FROM dbo.Pedidos";

                comando = new SqlCommand(strSQL, conexao);

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                da.Fill(ds);

                GridDados.DataSource = ds.Tables[0];

                MessageBox.Show("Pedido registrado com exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            
            try
            {

                strSQL = "UPDATE dbo.Pedidos SET statusPedido='Pago' WHERE  numeroPedido=@NumeroPedido;";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NumeroPedido", GridDados.SelectedRows[0].Cells[0].Value.ToString());

                conexao.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            try
            {
                strSQL = "Select * FROM dbo.Pedidos";

                comando = new SqlCommand(strSQL, conexao);

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                da.Fill(ds);

                GridDados.DataSource = ds.Tables[0];

                MessageBox.Show("Status do pedido alterado com exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                strSQL = "DELETE FROM dbo.Pedidos WHERE numeroPedido=@NumeroPedido;";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NumeroPedido", GridDados.SelectedRows[0].Cells[0].Value.ToString());

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            try 
            {
            strSQL = "SELECT * FROM dbo.Pedidos";

                comando = new SqlCommand(strSQL, conexao);

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                da.Fill(ds);

                GridDados.DataSource = ds.Tables[0];

                MessageBox.Show("Pedido concluido com exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}