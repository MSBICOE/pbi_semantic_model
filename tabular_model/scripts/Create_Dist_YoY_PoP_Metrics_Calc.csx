// Creates same period last year last year and previous period measure for every selected measure.
foreach(var m in Selected.Measures) {
                        
    m.Table.AddMeasure(
        m.Name + " +/- LY",                                       // Name
        "if(isblank([" + m.Name + " LY]), blank(), [" + m.Name + "] - ["  + m.Name + " LY])",     // DAX expression
        "Current Dist Metrics\\LY"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        m.Name + " +/- PP",                                       // Name
        "if(isblank([" + m.Name + " PP]), blank(), [" + m.Name + "] - ["  + m.Name + " PP])",    // DAX expression
        "Current Dist Metrics\\PP"                                        // Display Folder
    );
  
}
