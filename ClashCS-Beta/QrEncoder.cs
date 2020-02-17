using System.Drawing;

namespace ClashCS
{
    public static class QrEncoder
    {
        public static Bitmap code(string msg, int version, int pixel, bool white_edge)
        {
            QRCoder.QRCodeGenerator code_generator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData code_data = code_generator.CreateQrCode(msg, QRCoder.QRCodeGenerator.ECCLevel.M/* 这里设置容错率的一个级别 */, true, true, QRCoder.QRCodeGenerator.EciMode.Utf8, version);
            QRCoder.QRCode code = new QRCoder.QRCode(code_data);
            Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, white_edge);
            return bmp;
        }
    }
}
