namespace Server;

using NLog;
using Grpc.Core;

//this comes from GRPC generated code
using Services;


/// <summary>
/// Service. This is made to run as a singleton instance.
/// </summary>
public class Service : Services.Service.ServiceBase
{
	/// <summary>
	/// Logger for this class.
	/// </summary>
	Logger log = LogManager.GetCurrentClassLogger();

	/// <summary>
	/// Access lock.
	/// </summary>
	private readonly Object accessLock = new Object();

	/// <summary>
	/// Service logic implementation.
	/// </summary>
	private ServiceLogic logic = new ServiceLogic();


	/// <summary>
	/// Add input arguments.
	/// </summary>
	/// <param name="input">Parts to add.</param>
	/// <param name="context">Call context.</param>
	/// <returns>Result of addition operation.</returns>
	public override Task<AddOutput> Add(AddInput input, ServerCallContext context) {
		log.Info($"Service instance hash code: {this.GetHashCode()}.");

		lock( accessLock ) {				
			var result = new AddOutput { Value = logic.Add(input.Left, input.Right) };
			return Task.FromResult(result);				
		}
	}		
}