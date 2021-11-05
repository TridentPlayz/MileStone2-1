using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MileStone2
{
    public partial class ModuleRecords : Form
    {
        public ModuleRecords()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentRecords test = new StudentRecords();
            test.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.InsertUser(txtGender.Text, txtIdNumber.Text, txtName.Text, txtSurname.Text);
            txtName.Text = "";
            txtSurname.Text = "";
            txtGender.Text = "";
            txtIdNumber.Text = "";
        }

        private void ModuleRecords_Load(object sender, EventArgs e)
        {
            dh.DBAccess();
            Users u = new Users();

            BindingSource bs = new BindingSource();
            bs.DataSource = u.GetUsers();
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int word;
                listBox1.Items.Clear();
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                word = Convert.ToInt32(row.Cells["userId"].Value.ToString());

                Pet p = new Pet();
                foreach (var item in p.GetPets(word))
                {
                    listBox1.Items.Add($"Name: {item.Name}      Type: {item.PetType} Age: {item.Age}");
                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            MessageBox.Show(u.DeleteData(txtIdNumber.Text));
            txtName.Text = "";
            txtSurname.Text = "";
            txtGender.Text = "";
            txtIdNumber.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            txtName.Text = "";
            txtSurname.Text = "";
            txtGender.Text = "";
            txtIdNumber.Text = "";
            if (txtIdNumber.Text != "" && txtName.Text != "")
            {
                dh.updateName(Convert.ToInt32(txtIdNumber.Text), txtName.Text);

            }
            else if (txtIdNumber.Text != "" && txtSurname.Text != "")
            {
                dh.updateSurname(Convert.ToInt32(txtIdNumber.Text), txtSurname.Text);
            }
            else if (txtIdNumber.Text != "" && txtSurname.Text != "" && txtName.Text != "")
            {
                dh.updateAll(Convert.ToInt32(txtIdNumber.Text), txtName.Text, txtSurname.Text);
            }
        }
    }
}
