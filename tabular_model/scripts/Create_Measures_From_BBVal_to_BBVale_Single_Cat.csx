// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var mbase = Model.Tables["Fact_Banner_Brick_Sales"].Measures["BB Val Sales Single Cat"];
    var exp = mbase.Expression;
    var mname = m.Name;
    var mreplace = "Base " + m.Name;
    var mcreate = m.Name + " Single Cat";

                     
    exp = exp.Replace("Base BB Val Sales", mreplace);

    m.Table.AddMeasure(
        mcreate,                                       // Name
        exp,     // DAX expression
        "Current Period Metrics\\Discrete Metrics Single Cat"                                        // Display Folder
    );

}