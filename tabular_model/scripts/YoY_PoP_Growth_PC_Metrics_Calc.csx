// Creates same period last year last year and previous period measure for every selected measure.
foreach(var m in Selected.Measures) {
                        
    m.Table.AddMeasure(
        m.Name + " Gr % vs LY",                                       // Name
        "divide([" + m.Name + " +/- LY], [" + m.Name + " LY])",     // DAX expression
        "Year over Year Growth %"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        m.Name + " Gr % vs PP",                                       // Name
        "divide([" + m.Name + " +/- PP], [" + m.Name + " PP])",   // DAX expression
        "Period over Period Growth %"                                        // Display Folder
    );
  
}
