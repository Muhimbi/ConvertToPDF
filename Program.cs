using System.ServiceModel;
using ServiceReference1;

namespace PDF_Conversion
{
    class Program
    {        

        static void Main(string[] args)
        {
          //  new TestURLConversion();
            DocumentConverterServiceClient? client = null;

            try
            {
                // ** Determine the source file and read it into a byte array.
                string sourceFileName = "C:\\Converter\\test1.docx";

                byte[] sourceFile = File.ReadAllBytes(sourceFileName);

                // ** Open the service and configure the bindings
                client = UtilClass.OpenService();

                //** Set the absolute minimum open options
                OpenOptions openOptions = new OpenOptions();
                openOptions.OriginalFileName = Path.GetFileName(sourceFileName);
                openOptions.FileExtension = Path.GetExtension(sourceFileName);
               // openOptions.FileExtension = "PDF";

                // ** Set the absolute minimum conversion settings.
                ConversionSettings conversionSettings = new ConversionSettings();
                conversionSettings.Fidelity = ConversionFidelities.Full;
                conversionSettings.Quality = ConversionQuality.OptimizeForPrint;
                conversionSettings.Format = OutputFormat.PDF;
                conversionSettings.GenerateBookmarks = BookmarkGenerationOption.Automatic;

                // ** Carry out the conversion.
                Console.WriteLine("Converting file " + sourceFileName + " to PDF.");
                byte[] convFile = client.Convert(sourceFile, openOptions, conversionSettings);
             

                // ** Write the converted file back to the file system with a PDF extension.
                string destinationFileName = "C:\\Converter\\" + Path.GetFileNameWithoutExtension(sourceFileName)+"."+conversionSettings.Format;
                using (FileStream fs = File.Create(destinationFileName))
                {
                    fs.Write(convFile, 0, convFile.Length);
                    fs.Close();
                }

                Console.WriteLine("File converted to " + destinationFileName);
                System.Environment.Exit(0);
            }
            catch (FaultException<WebServiceFaultException> ex)
            {
                Console.WriteLine("FaultException occurred: ExceptionType: " +
                                 ex.Detail.ExceptionType.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (client != null)
                {
                    UtilClass.CloseService(client);
                }
            }
            Console.ReadKey();
        }

    }
}