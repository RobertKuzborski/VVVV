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
	[PluginInfo(Name = "VectorRotation", Category = "Value", Help = "Basic template with one value in/out", Tags = "c#")]
	#endregion PluginInfo
	public class ValueVectorRotationNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 1.0)]
		public ISpread<Vector2D> FInput;
		
		[Input("Angle", DefaultValue = 1.0)]
		public ISpread<double> a;

		[Output("Output x")]
		public ISpread<double> xo;
		
		[Output("Output y")]
		public ISpread<double> yo;

		[Import()]
		public ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			xo.SliceCount = SpreadMax;
			yo.SliceCount = SpreadMax;

			for (int i = 0; i < SpreadMax; i++)
			{
				
				//xo[i] = FInput[i].x;//[FInput[i].x * 2,2];
				a[i] = Math.PI * 2 * a[i];
				xo[i] = FInput[i].x * Math.Cos(a[i]) + FInput[i].y * -1 * Math.Sin(a[i]);
				yo[i] = FInput[i].x * Math.Sin(a[i]) + FInput[i].y  * Math.Cos(a[i]);
				//FOutput[i].x = 2;
			}
				

			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}
