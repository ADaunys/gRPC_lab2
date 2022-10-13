namespace Server;

using NLog;


/// <summary>
/// Networking independant service logic.
/// </summary>
public class ServiceLogic
{
	/// <summary>
	/// Logger for this class.
	/// </summary>
	Logger log = LogManager.GetCurrentClassLogger();

	/// <summary>
	/// Add the arguments, return result.
	/// </summary>
	/// <param name="left">Left argument of addition operation.</param>
	/// <param name="right">Right argument of addition operation.</param>
	/// <returns>Result of addition operation.</returns>
	public int Add(int left, int right) 
	{
		log.Info($"Add({left}, {right})");
		return left + right;
	}
}