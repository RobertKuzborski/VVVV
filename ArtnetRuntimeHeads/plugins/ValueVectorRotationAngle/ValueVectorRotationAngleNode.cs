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
	[PluginInfo(Name = "VectorRotationAngle", Category = "Value", Help = "Basic template with one value in/out", Tags = "c#")]
	#endregion PluginInfo
	public class ValueVectorRotationAngleNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("X", DefaultValue = 1.0)]
		public ISpread<double> x;
		
		[Input("Y", DefaultValue = 1.0)]
		public ISpread<double> y;
		
		[Input("Angle", DefaultValue = 1.0)]
		public ISpread<double> a;

		[Output("Rotated X")]
		public ISpread<double> xo;
		
		[Output("Rotated Y")]
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
				a[i] = Math.PI * 2 * a[i];
				xo[i] = x[i] * Math.Cos(a[i]) + y[i] * -1 * Math.Sin(a[i]);
				yo[i] = x[i] * Math.Sin(a[i]) + y[i]  * Math.Cos(a[i]);
			}
			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}
