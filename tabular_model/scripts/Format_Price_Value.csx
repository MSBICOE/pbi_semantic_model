// Creates same period last year last year and previous period measure for every selected measure.
foreach(var m in Selected.Measures) {
    
    // Format Price Value
    m.FormatString = "\\$#,0.00;-\\$#,0.00;\\$#,0.00";
  
}
