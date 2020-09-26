var targetTable = Model.Tables["Metric_Filter"]; 
foreach(var c in Selected.Columns)
{
    var newMeasure = targetTable.AddMeasure(
    "f_" + c.Name.Replace(" ", String.Empty),                    // Name
    "IsFiltered(" + c.DaxObjectFullName + ")"    // DAX expression
    );
    
    // Provide some documentation:
    newMeasure.Description = "This measure is to check if the object " + c.DaxObjectFullName + " is filtered";

    // Hide the base column:
    //c.IsHidden = true;
}