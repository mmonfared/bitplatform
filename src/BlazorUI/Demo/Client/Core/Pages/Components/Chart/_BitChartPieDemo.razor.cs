﻿namespace Bit.BlazorUI.Demo.Client.Core.Pages.Components.Chart;

public partial class _BitChartPieDemo
{
    private const int INITAL_COUNT = 5;

    private BitChart _chart = default!;
    private BitChartPieConfig _config = default!;

    protected override void OnInitialized()
    {
        _config = new BitChartPieConfig
        {
            Options = new BitChartPieOptions
            {
                Responsive = true,
                Title = new BitChartOptionsTitle
                {
                    Display = true,
                    Text = "BitChart Pie Chart"
                }
            }
        };

        BitChartPieDataset<int> dataset = new BitChartPieDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
        {
            BackgroundColor = BitChartDemoColors.All.Take(INITAL_COUNT).Select(c => BitChartColorUtil.FromDrawingColor(System.Drawing.Color.FromArgb(220, c))).ToArray()
        };
        _config.Data.Labels.AddRange(BitChartDemoUtils.Months.Take(INITAL_COUNT));
        _config.Data.Datasets.Add(dataset);
    }

    private void RandomizePieData()
    {
        foreach (IDataset<int> dataset in _config.Data.Datasets)
        {
            int count = dataset.Count;
            dataset.Clear();
            for (int i = 0; i < count; i++)
            {
                if (BitChartDemoUtils._rng.NextDouble() < 0.2)
                {
                    dataset.Add(0);
                }
                else
                {
                    dataset.Add(BitChartDemoUtils.RandomScalingFactor());
                }
            }
        }

        _chart.Update();
    }

    private void AddPieDataset()
    {
        int count = _config.Data.Labels.Count;
        BitChartPieDataset<int> dataset = new BitChartPieDataset<int>(BitChartDemoUtils.RandomScalingFactor(count, -100, 100))
        {
            BackgroundColor = BitChartDemoColors.All.Take(count).Select(BitChartColorUtil.FromDrawingColor).ToArray()
        };

        _config.Data.Datasets.Add(dataset);
        _chart.Update();
    }

    private void RemovePieDataset()
    {
        IList<IBitChartDataset> datasets = _config.Data.Datasets;
        if (datasets.Count == 0)
            return;

        datasets.RemoveAt(0);
        _chart.Update();
    }

    private void AddPieData()
    {
        if (_config.Data.Datasets.Count == 0)
            return;

        string month = BitChartDemoUtils.Months[_config.Data.Labels.Count % BitChartDemoUtils.Months.Count];
        _config.Data.Labels.Add(month);

        foreach (IDataset<int> dataset in _config.Data.Datasets)
        {
            dataset.Add(BitChartDemoUtils.RandomScalingFactor());
        }

        _chart.Update();
    }

    private void RemovePieData()
    {
        if (_config.Data.Datasets.Count == 0 ||
            _config.Data.Labels.Count == 0)
        {
            return;
        }

        _config.Data.Labels.RemoveAt(_config.Data.Labels.Count - 1);

        foreach (IDataset<int> dataset in _config.Data.Datasets)
        {
            dataset.RemoveAt(dataset.Count - 1);
        }

        _chart.Update();
    }



    private readonly string htmlCode = @"
<BitChart Config=""_config"" @ref=""_chart"" />

<div>
    <BitButton OnClick=""RandomizePieData"">Randomize Data</BitButton>
    <BitButton OnClick=""AddPieDataset"">Add Dataset</BitButton>
    <BitButton OnClick=""RemovePieDataset"">Remove Dataset</BitButton>
    <BitButton OnClick=""AddPieData"">Add Data</BitButton>
    <BitButton OnClick=""RemovePieData"">Remove Data</BitButton>
</div>";
    private readonly string csharpCode = @"
private const int INITAL_COUNT = 5;

private BitChart _chart = default!;
private BitChartPieConfig _config = default!;

protected override void OnInitialized()
{
    _config = new BitChartPieConfig
    {
        Options = new BitChartPieOptions
        {
            Responsive = true,
            Title = new BitChartOptionsTitle
            {
                Display = true,
                Text = ""BitChart Pie Chart""
            }
        }
    };

    BitChartPieDataset<int> dataset = new BitChartPieDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
    {
        BackgroundColor = BitChartDemoColors.All.Take(INITAL_COUNT).Select(c => BitChartColorUtil.FromDrawingColor(System.Drawing.Color.FromArgb(220, c))).ToArray()
    };
    _config.Data.Labels.AddRange(BitChartDemoUtils.Months.Take(INITAL_COUNT));
    _config.Data.Datasets.Add(dataset);
}

private void RandomizePieData()
{
    foreach (IDataset<int> dataset in _config.Data.Datasets)
    {
        int count = dataset.Count;
        dataset.Clear();
        for (int i = 0; i < count; i++)
        {
            if (BitChartDemoUtils._rng.NextDouble() < 0.2)
            {
                dataset.Add(0);
            }
            else
            {
                dataset.Add(BitChartDemoUtils.RandomScalingFactor());
            }
        }
    }

    _chart.Update();
}

private void AddPieDataset()
{
    int count = _config.Data.Labels.Count;
    BitChartPieDataset<int> dataset = new BitChartPieDataset<int>(BitChartDemoUtils.RandomScalingFactor(count, -100, 100))
    {
        BackgroundColor = BitChartDemoColors.All.Take(count).Select(BitChartColorUtil.FromDrawingColor).ToArray()
    };

    _config.Data.Datasets.Add(dataset);
    _chart.Update();
}

private void RemovePieDataset()
{
    IList<IBitChartDataset> datasets = _config.Data.Datasets;
    if (datasets.Count == 0)
        return;

    datasets.RemoveAt(0);
    _chart.Update();
}

private void AddPieData()
{
    if (_config.Data.Datasets.Count == 0)
        return;

    string month = BitChartDemoUtils.Months[_config.Data.Labels.Count % BitChartDemoUtils.Months.Count];
    _config.Data.Labels.Add(month);

    foreach (IDataset<int> dataset in _config.Data.Datasets)
    {
        dataset.Add(BitChartDemoUtils.RandomScalingFactor());
    }

    _chart.Update();
}

private void RemovePieData()
{
    if (_config.Data.Datasets.Count == 0 ||
        _config.Data.Labels.Count == 0)
    {
        return;
    }

    _config.Data.Labels.RemoveAt(_config.Data.Labels.Count - 1);

    foreach (IDataset<int> dataset in _config.Data.Datasets)
    {
        dataset.RemoveAt(dataset.Count - 1);
    }

    _chart.Update();
}

public static class BitChartDemoColors
{
    private static readonly Lazy<IReadOnlyList<System.Drawing.Color>> _all = new Lazy<IReadOnlyList<System.Drawing.Color>>(() => new System.Drawing.Color[7]
    {
                Red, Orange, Yellow, Green, Blue, Purple, Grey
    });

    public static IReadOnlyList<System.Drawing.Color> All => _all.Value;

    public static readonly System.Drawing.Color Red = System.Drawing.Color.FromArgb(255, 99, 132);
    public static readonly System.Drawing.Color Orange = System.Drawing.Color.FromArgb(255, 159, 64);
    public static readonly System.Drawing.Color Yellow = System.Drawing.Color.FromArgb(255, 205, 86);
    public static readonly System.Drawing.Color Green = System.Drawing.Color.FromArgb(75, 192, 192);
    public static readonly System.Drawing.Color Blue = System.Drawing.Color.FromArgb(54, 162, 235);
    public static readonly System.Drawing.Color Purple = System.Drawing.Color.FromArgb(153, 102, 255);
    public static readonly System.Drawing.Color Grey = System.Drawing.Color.FromArgb(201, 203, 207);
}

public static class BitChartDemoUtils
{
    public static readonly Random _rng = new Random();

    public static IReadOnlyList<string> Months { get; } = new ReadOnlyCollection<string>(new[]
    {
            ""January"", ""February"", ""March"", ""April"", ""May"", ""June"", ""July"", ""August"", ""September"", ""October"", ""November"", ""December""
    });

    private static int RandomScalingFactorThreadUnsafe(int min, int max) => _rng.Next(min, max);

    public static int RandomScalingFactor()
    {
        lock (_rng)
        {
            return RandomScalingFactorThreadUnsafe(0, 100);
        }
    }

    public static IEnumerable<int> RandomScalingFactor(int count, int min = 0, int max = 100)
    {
        int[] factors = new int[count];
        lock (_rng)
        {
            for (int i = 0; i < count; i++)
            {
                factors[i] = RandomScalingFactorThreadUnsafe(min, max);
            }
        }

        return factors;
    }

    public static IEnumerable<DateTime> GetNextDays(int count)
    {
        DateTime now = DateTime.Now;
        DateTime[] factors = new DateTime[count];
        for (int i = 0; i < factors.Length; i++)
        {
            factors[i] = now.AddDays(i);
        }

        return factors;
    }
}

public static class IListExtensions
{
    public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
    {
        if (list == null)
            throw new ArgumentNullException(nameof(list));

        if (items == null)
            throw new ArgumentNullException(nameof(items));

        if (list is List<T> asList)
        {
            asList.AddRange(items);
        }
        else
        {
            foreach (T item in items)
            {
                list.Add(item);
            }
        }
    }
}";
}