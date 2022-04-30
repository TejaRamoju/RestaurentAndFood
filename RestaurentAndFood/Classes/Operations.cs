using Aspose.Cells;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurentAndFood.Classes
{
    public class Operations
    {
        Constants paths = new Constants();
        Logger logger = new Logger();
        //using treditional approach
        public string ConvertToJson()
        {
            try
            {
                var lines = logger.readFile(paths.DataFilePath);

                var csv = new List<string[]>();
                foreach (string line in lines)
                {
                    try
                    {
                    csv.Add(line.Split(','));

                    }
                    catch (Exception ex)
                    {

                        logger.writeFile(paths.ErrorFilePath,ex.Message, Convert.ToInt32(line));
                    }

                }
                var properties = lines[0].Split(',');
                var listObjResult = new List<Dictionary<string, string>>();
                for (int i = 1; i < lines.Length; i++)
                {
                    try
                    {
                        var objResult = new Dictionary<string, string>();
                        for (int j = 0; j < properties.Length; j++)
                        {
                            objResult.Add(properties[j], csv[i][j]);
                        }
                        listObjResult.Add(objResult);
                    }
                    catch (Exception ex)
                    {

                        logger.writeFile(paths.ErrorFilePath, ex.Message, i);
                    }
                    
                }
                return JsonConvert.SerializeObject(listObjResult);
            }
            catch (Exception ex)
            {

                logger.writeFile(paths.ErrorFilePath, ex.Message, 0);
                return ex.Message;
            }
            
        }


        //using Aspose Lib
        public string ConvertToJson1()
        {

            try
            {

                //loading options for csv data
                LoadOptions loadOptions = new LoadOptions(LoadFormat.CSV);
                //loading csv file 
                Workbook workbook = new Workbook(paths.ErrorFilePath, loadOptions);
                //calculating the last cell range
                Cell lastCell = workbook.Worksheets[0].Cells.LastCell;

                // Set ExportRangeToJsonOptions
                Aspose.Cells.Utility.ExportRangeToJsonOptions options = new Aspose.Cells.Utility.ExportRangeToJsonOptions();
                Aspose.Cells.Range range = workbook.Worksheets[0].Cells.CreateRange(0, 0, lastCell.Row + 1, lastCell.Column + 1);
                string data = Aspose.Cells.Utility.JsonUtility.ExportRangeToJson(range, options);

                // return the Json Data
                return data;
            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }
    }
}