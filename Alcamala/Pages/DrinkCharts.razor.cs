using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Alcamala.Pages;

public partial class DrinkCharts
{
    private ISeries[] _series = [];

    protected override void OnInitialized()
    {
        var values = Fetch();

        _series =
        [
            new LineSeries<int>
            {
                Values = values
            }
        ];
    }

    private static int[] Fetch()
    {
        var values = new int[100];
        var r = new Random();
        var t = 0;
        for (var i = 0; i < 100; i++)
        {
            t += r.Next(-90, 100);
            values[i] = t;
        }
        return values;
    }
}
