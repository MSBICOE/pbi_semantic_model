// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var mbase = Model.Tables["Fact_Banner_Brick_Sales"].Measures["BB Val Sales Single Cat"];
    var exp = m.Expression;
    var mname = m.Name;
    var mreplace = "Base ST ";
    var mcreate = m.Name.Replace("BB ", "ST ");

                     
    exp = exp.Replace("Base BB ", mreplace);

    Model.Tables["Fact_Store_Sales"].AddMeasure(
        mcreate,                                       // Name
        exp,     // DAX expression
        "Current Period Metrics\\Discrete Metrics Singel Cat"                                        // Display Folder
    );

}