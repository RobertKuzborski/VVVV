#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "CounterQ", Category = "Value", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class ValueCounterQNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0.0)]
		public ISpread<double> FInput;
		
		[Input("Max", DefaultValue = 10.0)]
		public ISpread<double> FMax;

		[Output("Output")]
		public ISpread<double> FOutput;

		[Import()]
		public ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = SpreadMax;
			FMax.SliceCount = SpreadMax;
					
			for (int i = 0; i < SpreadMax; i++) {
			
				
			
			if (FOutput[i] > FMax[i])
			
				FOutput[i] = 0.0 ;
				
				FOutput[i] = FOutput[i] + FInput[i] ;
				
			}

			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}
