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
    public partial class EditForm : Form
    {
        public Active EditActive { get; set; }

        public EditForm()
        {
            InitializeComponent();
        }

        public void LoadingDataForm()
        {
            if (EditActive.Equals(null))
            {
                return;
            }
            tActiveName.Text = EditActive.Name;
            foreach (var item in EditActive.GetParams())
            {
                ParamsGrid.Rows.Add(item.ParamName,item.ParamContent);
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            List<ParamActive> Params = new List<ParamActive>();
            for (int i = 0; i < ParamsGrid.RowCount-1; i++)
            {
                Params.Add(new ParamActive(ParamsGrid[0, i].Value.ToString(), ParamsGrid[1, i].Value.ToString()));
            }
            EditActive.Name = tActiveName.Text;
            EditActive.SetParams(Params);           
        }
    }
}
