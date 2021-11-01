using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.Sources
{
    public class TestColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Thistle; }
        }
        Color culoare = Color.Thistle;
        Color culoare1 = Color.Thistle;

        public override Color MenuItemBorder
        {
            get { return culoare; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return culoare; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return culoare; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return culoare; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return culoare; }
        }
        public override Color MenuBorder  //added for changing the menu border
        {
            get { return Color.Thistle; }
        }
    }
}
