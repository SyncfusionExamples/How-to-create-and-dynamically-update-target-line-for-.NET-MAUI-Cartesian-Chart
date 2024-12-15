# How to create and dynamically update target line for .NET MAUI Cartesian Chart
This article provides a detailed walkthrough on how to add arrows to the axis using Annotations in [.NET MAUI Cartesian Chart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts).

The [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html) includes support for [Annotations](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_Annotations), enabling the addition of various types of annotations to enhance chart visualization. Using [HorizontalLineAnnotation](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.HorizontalLineAnnotation.html), you can create and dynamically adjust the target line.

The Horizontal Line Annotation includes following property:

* [Y1](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAnnotation.html#Syncfusion_Maui_Charts_ChartAnnotation_Y1) - Gets or sets the Y1 coordinate of the horizontal line annotation.
* [Stroke](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ShapeAnnotation.html#Syncfusion_Maui_Charts_ShapeAnnotation_Stroke) - Gets or sets the stroke color of the horizontal line annotation.
* [StrokeWidth](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ShapeAnnotation.html#Syncfusion_Maui_Charts_ShapeAnnotation_StrokeWidth) - Gets or sets the stroke width of the horizontal line annotation.
* [StrokeDashArray](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ShapeAnnotation.html#Syncfusion_Maui_Charts_ShapeAnnotation_StrokeDashArray) - Gets or sets the stroke dash pattern of the horizontal line annotation.
* [Text](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ShapeAnnotation.html#Syncfusion_Maui_Charts_ShapeAnnotation_Text) - Gets or sets the annotation text of the horizontal line annotation.
* [LabelStyle](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ShapeAnnotation.html#Syncfusion_Maui_Charts_ShapeAnnotation_LabelStyle) - Gets or sets the style for customizing the annotation text of the horizontal line annotation.

Learn step-by-step instructions and gain insights to create and dynamically update the target line.

**Step 1:** The layout is created using a Grid with two columns.

**XAML**
 
 ```xml
<Grid>

    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"></ColumnDefinition>
        <ColumnDefinition Width="200"></ColumnDefinition>
    </Grid.ColumnDefinitions>

</Grid> 
 ```
 
**Step 2:** In first column of grid layout, initialize the [SfCartesianChart](https://help.syncfusion.com/maui/cartesian-charts/getting-started) and add the axes and series to the [SfCartesianChart](https://help.syncfusion.com/maui/cartesian-charts/getting-started) as shown below.

**XAML**

 ```xml
<chart:SfCartesianChart Grid.Column="0">

    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis ShowMajorGridLines="False">
            .....
        </chart:CategoryAxis>
    </chart:SfCartesianChart.XAxes>

    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis x:Name="Y_Axis" Minimum="0" Maximum="20000" Interval="5000" ShowMajorGridLines="False" PlotOffsetEnd="30">
            .....
        </chart:NumericalAxis>
    </chart:SfCartesianChart.YAxes>

    <chart:ColumnSeries ItemsSource="{Binding Data}"
                    XBindingPath="Months"
                    YBindingPath="Revenue"
                    PaletteBrushes="{Binding CustomBrushes}"
                    Opacity="0.7"/>

</chart:SfCartesianChart> 
 ```
 
**Step 3:** The [HorizontalLineAnnotation](https://help.syncfusion.com/maui/cartesian-charts/annotation#vertical-and-horizontal-line-annotations) is initialized within the [Annotations](https://help.syncfusion.com/maui/cartesian-charts/annotation) collection of the [SfCartesianChart](https://help.syncfusion.com/maui/cartesian-charts/getting-started) to mark a dynamic target value on the Y-axis. The Y1 value is data-bound, enabling the target line to update dynamically based on the ViewModel.

**XAML**
 
 ```xml
<chart:SfCartesianChart Grid.Column="0">

    <chart:SfCartesianChart.Annotations>
        <chart:HorizontalLineAnnotation Y1="{Binding Y1}"
                                Stroke="Black"
                                StrokeWidth="2"
                                StrokeDashArray="5,2,2"
                                Text="Target">
                <chart:HorizontalLineAnnotation.LabelStyle>
                    <chart:ChartAnnotationLabelStyle TextColor="Black" FontSize="14" FontAttributes="Bold" HorizontalTextAlignment="Start" VerticalTextAlignment="Start"/>
                </chart:HorizontalLineAnnotation.LabelStyle>
            </chart:HorizontalLineAnnotation>
    </chart:SfCartesianChart.Annotations>

</chart:SfCartesianChart> 
 ```
 
**C#**

 ```csharp
internal class ViewModel : INotifyPropertyChanged
{
    private double y1;
    public double Y1
    {
        get => y1;
        set
        {
            if(y1 != value)
            {
                y1 = value;
                OnPropertyChanged(nameof(Y1));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    .....

    public ViewModel()
    {
        Y1 = 12000;
        .....
    }
} 
 ```
 
**Step 4:** The second column of the grid layout contains a VerticalStackLayout with a Slider and an Entry box, allowing the user to change the annotation value dynamically.

**XAML**
 
 ```xml
<VerticalStackLayout Spacing="5" Grid.Column="1" Padding="10">

    <Label Text="Adjust Target Line" FontSize="16" FontAttributes="Bold" HorizontalOptions="Center"/>
    <Entry Text="{Binding Y1}" Keyboard="Numeric" TextChanged="Entry_TextChanged"/>
    <Slider Minimum="{Binding Minimum, Source={x:Reference Y_Axis}}" Maximum="{Binding Maximum, Source={x:Reference Y_Axis}}" Value="{Binding Y1}"/>
    
</VerticalStackLayout>
 ```
 

**Output:**

![DynamicTargetLine](https://github.com/user-attachments/assets/737beb67-861f-44f6-815f-3f6dde45d8fc)


