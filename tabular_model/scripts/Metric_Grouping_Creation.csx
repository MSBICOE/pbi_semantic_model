

var measureMetadata = ReadFile(@"C:/Users/steven.wang/Documents/PBI_Semantic/sdata/fact_metric_grouping.txt"); //import 


// Split the file into rows by CR and LF characters:
var tsvRows = measureMetadata.Split(new[] {'\r','\n'},StringSplitOptions.RemoveEmptyEntries);

var measures = Selected.Measures;


foreach(var row in tsvRows.Skip(1))
{
    var tsvColumns = row.Split('\t');     // Assume file uses tabs as column separator
    var name = tsvColumns[0];             // 1st column contains measure name
    //var level_1 = tsvColumns[1];      // get to hide value 0 or 1
    //var level_2 = tsvColumns[5]; 
    //var display = level_1 + "\\" + level_2;
    foreach(var m in measures)
        {
            if (name == m.Name)
            {
                var level_1 = tsvColumns[1];      // get to hide value 0 or 1
                var level_2 = tsvColumns[5]; 
                var display = level_1 + "\\" + level_2;
                
                m.DisplayFolder = display;
        }
        }

}





