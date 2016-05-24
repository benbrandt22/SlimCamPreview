using System.Windows.Forms;

namespace SlimCamPreview
{
    public class TransparentPanel : Panel
    {
        // REF: http://stackoverflow.com/a/15523544/641985

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
}
