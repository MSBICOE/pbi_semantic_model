
foreach(var c in Selected.Columns)
{
    c.IsHidden = false;
}

var measureMetadata = ReadFile(@"C:/Users/steven.wang/Documents/PBI_Semantic/sdata/Bayer_column_hide.txt"); //import 
//var measureMetadata = ReadFile(@"C:/Users/steven.wang/Documents/PBI_Semantic/sdata/IQVIA_column_hide.txt"); //import 


// Split the file into rows by CR and LF characters:
var tsvRows = measureMetadata.Split(new[] {'\r','\n'},StringSplitOptions.RemoveEmptyEntries);

var cols = Selected.Columns;


foreach(var row in tsvRows.Skip(1))
{
    var tsvColumns = row.Split('\t');     // Assume file uses tabs as column separator
    var name = tsvColumns[2];             // 1st column contains measure name
    var to_hide = tsvColumns[3].Equals("1") ? true : false;      // get to hide value 0 or 1

    foreach(var c in cols)
        {
            if (name == c.Name)
            {
                c.IsHidden = to_hide;
        }
        }

}





