using Alcamala.Models.Firestore;
using Fireblaze.Firestore.Extensions;
using Fireblaze.Firestore.Helpers;
using Fireblaze.Firestore.Models;
using Fireblaze.Firestore.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Blazor;

namespace Alcamala.Pages;

public partial class Drinks : BasePage
{
    private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);
    private List<Drink> _todaysDrinks = [];

    private CartesianChart _chart = new();
    private ISeries[] _series = [];

    protected override async Task OnInitializedAsync()
    {
        _todaysDrinks = await GetDrinksForDateAsync(_selectedDate);

        _series =
        [
            new LineSeries<int>
            {
                Name = nameof(Drink.Amount),
                Values = [.. _todaysDrinks.Select(drink => drink.Amount)]
            }
        ];
    }

    private async Task<List<Drink>> GetDrinksForDateAsync(DateOnly date)
    {
        var todayStart = date.ToDateTime(TimeOnly.MinValue);
        var todayEnd = date.ToDateTime(TimeOnly.MaxValue);

        var dateOperator = new AndOperator(
            new WhereOperator<DateTime>("consumed", Comparer.GreaterThan, todayStart),
            new WhereOperator<DateTime>("consumed", Comparer.LessThan, todayEnd)
        );

        return await FirestoreService.GetCollection<Drink>(dateOperator).OwnedBy(CurrentUser.Uid).ToListAsync();
    }

    private async Task SelectedDateChanged(DateOnly selectedDate)
    {
        if (selectedDate == _selectedDate) return;

        _selectedDate = selectedDate;

        _todaysDrinks = await GetDrinksForDateAsync(_selectedDate);

        _series =
        [
            new LineSeries<int>
            {
                Name = nameof(Drink.Amount),
                Values = [.. _todaysDrinks.Select(drink => drink.Amount)]
            }
        ];
    }
}
