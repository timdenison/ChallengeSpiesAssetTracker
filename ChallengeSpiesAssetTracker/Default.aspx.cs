using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        string[] assetArray;
        double[] electionsArray;
        double[] subterfugeArray;

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                assetArray = new string[0];
                electionsArray = new double[0];
                subterfugeArray = new double[0];
                ViewState.Add("Assets", assetArray);
                ViewState.Add("Elections", electionsArray);
                ViewState.Add("Subterfuge", subterfugeArray);
            }
            else
            {
                if (ViewState["Assets"] != null)
                {
                   
                }
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            //Resize each array to have one more entry
            string[] assetArray = (string[])ViewState["Assets"];
            double[] electionsArray = (double[])ViewState["Elections"];
            double[] subterfugeArray = (double[])ViewState["Subterfuge"];

            Array.Resize(ref assetArray, assetArray.Length + 1);
            Array.Resize(ref electionsArray, electionsArray.Length + 1);
            Array.Resize(ref subterfugeArray, subterfugeArray.Length + 1);
            

            //place textbox contents in more recently available slot
            int index = assetArray.Length - 1;
            assetArray[index] = assetTextBox.Text;
            electionsArray[index] = double.Parse(electionsTextBox.Text);
            subterfugeArray[index] = double.Parse(subterfugeTextBox.Text);
            double electionsTotal = electionsArray.Sum();
            double subterfugeAvg = subterfugeArray.Average();

            ViewState.Add("Assets", assetArray);
            ViewState.Add("Elections", electionsArray);
            ViewState.Add("Subterfuge", subterfugeArray);

            resultLabel.Text = String.Format("Last Asset: {0}. Total Elections: {1}. Avg Subterfuge: {2:0.00}", assetArray[index], electionsTotal, subterfugeAvg);



        }
    }
}