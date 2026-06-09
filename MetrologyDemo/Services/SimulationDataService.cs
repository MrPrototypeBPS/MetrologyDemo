using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MetrologyDemo.Models;

namespace MetrologyDemo.Services;

/// <summary>
/// A concrete implementation of <see cref="IMeasurementDataService"/> that simulates 
/// a hardware connection to a Coordinate Measuring Machine (CMM) by generating random 3D point cloud data.
/// </summary>
public class SimulationDataService : IMeasurementDataService
{
    /// <summary>
    /// Asynchronously generates a dummy dataset of 3D measurement points.
    /// Includes simulated network latency and a random chance of hardware failure to test UI resilience.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation before completion.</param>
    /// <returns>An enumerable collection of <see cref="MeasurementPoint"/> objects.</returns>
    /// <exception cref="InvalidOperationException">Thrown randomly (10% chance) to simulate a hardware disconnect.</exception>
    /// <exception cref="OperationCanceledException">Thrown if the cancellation token is triggered.</exception>
    public async Task<IEnumerable<MeasurementPoint>> GetMeasurementDataAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(1500, cancellationToken);

        if (new Random().Next(1, 11) == 1)
        {
            throw new InvalidOperationException("Connection to the CMM hardware was lost.");
        }

        var points = new List<MeasurementPoint>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            points.Add(new MeasurementPoint
            {
                X = Math.Round(random.NextDouble() * 100, 4),
                Y = Math.Round(random.NextDouble() * 100, 4),
                Z = Math.Round(random.NextDouble() * 50, 4)
            });
        }

        return points;
    }
}