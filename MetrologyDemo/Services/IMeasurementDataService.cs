using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MetrologyDemo.Models;

namespace MetrologyDemo.Services;

/// <summary>
/// Defines the contract for retrieving coordinate measurement data.
/// </summary>
public interface IMeasurementDataService
{
    /// <summary>
    /// Asynchronously retrieves a collection of measurement points.
    /// </summary>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    Task<IEnumerable<MeasurementPoint>> GetMeasurementDataAsync(CancellationToken cancellationToken = default);
}