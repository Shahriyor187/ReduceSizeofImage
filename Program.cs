using System.Drawing;
using System.Drawing.Imaging;
class Program
{
    static void Main(string[] args)
    {
        //Your image address. Example:
        string sourcePath = "F:\\website.jpg";
        //Output image address. Example:
        string outputPath = "C:\\Users\\Intel Computers\\source\\repos\\Image\\output.jpg";
        // Load the image
        using (Bitmap sourceImage = new Bitmap(sourcePath))
        {
            // Reduce dimensions by half
            int newWidth = sourceImage.Width / 2;
            int newHeight = sourceImage.Height / 2;

            using (Bitmap resizedImage = new Bitmap(sourceImage, newWidth, newHeight))
            {
                // Save the image with JPEG compression
                EncoderParameters encoderParams = new EncoderParameters(1);
                //you can change qaulity of image 
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 70L); // Adjust quality here
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                if (jpegCodec != null)
                {
                    resizedImage.Save(outputPath, jpegCodec, encoderParams);
                    Console.WriteLine("Image saved successfully.");
                }
                else
                {
                    Console.WriteLine("JPEG codec not found.");
                }
            }
        }
    }

    // Helper method to get JPEG encoder info
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.MimeType == mimeType)
            {
                return codec;
            }
        }
        return null;
    }
}