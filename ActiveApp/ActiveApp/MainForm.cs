using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveApp
{
    public partial class MainForm : Form
    {
        public List<Active> actives = new List<Active>();

        public MainForm()
        {
            InitializeComponent();
            GetActiveList();
            UpdateActiveListBox();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (listBoxActive.SelectedIndex >= 0)
            {
                Active active = (Active)listBoxActive.Items[listBoxActive.SelectedIndex];
                using (EditForm editForm = new EditForm())
                {
                    editForm.EditActive = active;
                    editForm.LoadingDataForm();
                    editForm.ShowDialog();
                    UpdateActiveListBox();
                }
            }
            else
            {
                MessageBox.Show("Актив не выбран!");
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Active active = new Active();
            using (EditForm editForm = new EditForm())
            {
                editForm.EditActive = active;
                editForm.LoadingDataForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    actives.Add(active);
                }
                UpdateActiveListBox();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (listBoxActive.SelectedIndex >= 0)
            {
                Active active = (Active)listBoxActive.Items[listBoxActive.SelectedIndex];
                actives.Remove(active);
                UpdateActiveListBox();
            }
            else
            {
                MessageBox.Show("Актив не выбран!");
            }
        }

        private void UpdateActiveListBox()
        {
            listBoxActive.Items.Clear();
            foreach (var active in actives)
            {
                listBoxActive.Items.Add(active);
            }
            listBoxActive.DisplayMember = "Name";
        }

        private void GetActiveList()
        {
            Active active1 = new Active { Name = "счет № 5" };
            active1.Add(new ParamActive("Банк", "ЕвроВорБанке"));
            active1.Add(new ParamActive("Кол-во денег", "1000"));
            active1.Add(new ParamActive("Валюта", "рубль"));
            actives.Add(active1);

            Active active2 = new Active { Name = "счет № 3" };
            active2.Add(new ParamActive("Банк", "Внешторгабк"));
            active2.Add(new ParamActive("Кол-во денег", "5"));
            active2.Add(new ParamActive("Валюта", "доллар"));
            actives.Add(active2);

            Active active3 = new Active { Name = "касса" };
            active3.Add(new ParamActive("Кол-во денег", "100"));
            active3.Add(new ParamActive("Валюта", "рубль"));
            actives.Add(active3);

            Active active4 = new Active { Name = "касса талонов на бензин" };
            active4.Add(new ParamActive("Компания", "Аспек"));
            active4.Add(new ParamActive("Кол-во денег", "3000"));
            active4.Add(new ParamActive("Валюта", "рубль"));
            actives.Add(active4);
        }
    }
}
