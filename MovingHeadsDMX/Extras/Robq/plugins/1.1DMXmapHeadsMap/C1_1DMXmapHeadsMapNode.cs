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
	[PluginInfo(Name = "HeadsMap", Category = "DMXmap", Version = "1.1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class C1_1DMXmapHeadsMapNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 1.0)]
		public ISpread<double> FInput;

		[Output("Output")]
		public ISpread<double> FOutput;

		[Import()]
		public ILogger FLogger;
		#endregion fields & pins
		
		[Input("X Floor (meters)")]
        public ISpread<double> xFloor;
		
		[Input("y Floor (meters)")]
        public ISpread<double> yFloor;
		
		[Input("Height (meters)")]
        public ISpread<double> hFloor;
		
		[Output("Pan (degrees)")]
        public ISpread<double> pan;
		
		[Output("Tilt (degrees)")]
        public ISpread<double> tilt;
		
		[Output("Tilt Pitagorass")]
        public ISpread<double> pita;
		

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			
			
			for (int i = 0; i < SpreadMax; i++)
			{
				//double xFloorMap = 
			if ( yFloor[i] == xFloor[i] ) pan[i] = 0;
			else{
			pan[i] = Math.Atan( yFloor[i] / xFloor[i] ) * (180 / Math.PI);
				}
			pita[i] = Math.Sqrt(xFloor[i] * xFloor[i] + yFloor[i] * yFloor[i]);
			tilt[i] = Math.Atan( pita[i] / hFloor[i] ) * (180 / Math.PI);
				
			}
			
				
			
			
			
			
			FOutput.SliceCount = SpreadMax;

			for (int i = 0; i < SpreadMax; i++)
				FOutput[i] = Math.Sqrt(xFloor[i] * xFloor[i] + yFloor[i] * yFloor[i]); //* xFloor[i] * yFloor[i] *hFloor[i];

			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}
