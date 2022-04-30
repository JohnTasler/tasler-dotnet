using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace Tasler.Multimedia.DirectShow
{
	public static class GraphUtility
	{
		public static void ClearFilters(this IFilterGraph filterGraph)
		{
			var filters = new List<IBaseFilter>(filterGraph.GetFilters());
			foreach (var filter in filters)
			{
				filterGraph.RemoveFilter(filter);
				Marshal.ReleaseComObject(filter);
			}
		}

		public static IEnumerable<IBaseFilter> GetFilters(this IFilterGraph filterGraph)
		{
			if (filterGraph == null)
				throw new ArgumentNullException("filterGraph");
			return new FilterEnum<IBaseFilter>(filterGraph);
		}

		public static IEnumerable<T> GetFilters<T>(this IFilterGraph filterGraph)
			where T : class
		{
			if (filterGraph == null)
				throw new ArgumentNullException("filterGraph");
			return new FilterEnum<T>(filterGraph);
		}

		public static IEnumerable<IBaseFilter> GetFilters(this IFilterGraph filterGraph, AMFilterMiscFlags flags)
		{
			var miscFlags = (int)flags;
			foreach (var filter in filterGraph.GetFilters<IAMFilterMiscFlags>())
			{
				if (miscFlags == (filter.GetMiscFlags() & miscFlags))
					yield return (IBaseFilter)filter;
				else
					Marshal.ReleaseComObject(filter);
			}
		}

		public static IEnumerable<IBaseFilter> GetSourceFilters(this IFilterGraph filterGraph)
		{
			return filterGraph.GetFilters(AMFilterMiscFlags.IsSource);
		}

		public static IEnumerable<IBaseFilter> GetRenderers(this IFilterGraph filterGraph)
		{
			return filterGraph.GetFilters(AMFilterMiscFlags.IsRenderer);
		}

		public static int GetRendererCount(this IFilterGraph filterGraph)
		{
			int count = 0;
			foreach (IBaseFilter renderer in filterGraph.GetRenderers())
			{
				++count;
				Marshal.ReleaseComObject(renderer);
			}
			return count;
		}

		private class FilterEnum<T> : IEnumerable<T>
			where T : class
		{
			private IFilterGraph filterGraph;

			public FilterEnum(IFilterGraph filterGraph)
			{
				this.filterGraph = filterGraph;
			}

			#region IEnumerable<T> Members

			public IEnumerator<T> GetEnumerator()
			{
				IEnumFilters enumFilters = null;
				try
				{
					int hr = this.filterGraph.EnumFilters(out enumFilters);
					DsError.ThrowExceptionForHR(hr);

					var filters = new IBaseFilter[1];
					while (0 == enumFilters.Next(1, filters, IntPtr.Zero))
					{
						T filter = filters[0] as T;
						if (filter != null)
							yield return filter;
						else
							Marshal.ReleaseComObject(filters[0]);
					}
				}
				finally
				{
					if (enumFilters != null)
						Marshal.ReleaseComObject(enumFilters);
				}
			}

			#endregion IEnumerable<T> Members

			#region IEnumerable Members

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			#endregion IEnumerable Members
		}
	}

	public static class FilterUtility
	{
		public static IEnumerable<IPin> GetPins(this IBaseFilter filter)
		{
			if (filter == null)
				throw new ArgumentNullException("pin");
			return new PinEnum<IPin>(filter);
		}

		public static IEnumerable<T> GetPins<T>(this IBaseFilter filter)
			where T : class
		{
			if (filter == null)
				throw new ArgumentNullException("pin");
			return new PinEnum<T>(filter);
		}

		public static IEnumerable<IPin> GetPins(this IBaseFilter filter, PinDirection direction)
		{
			foreach (var pin in filter.GetPins())
			{
				PinDirection pinDirection;
				pin.QueryDirection(out pinDirection);
				if (pinDirection == direction)
					yield return pin;
				else
					Marshal.ReleaseComObject(pin);
			}
		}

		private class PinEnum<T> : IEnumerable<T>
			where T : class
		{
			private IBaseFilter filter;

			public PinEnum(IBaseFilter filter)
			{
				this.filter = filter;
			}

			#region IEnumerable<T> Members

			public IEnumerator<T> GetEnumerator()
			{
				IEnumPins enumPins = null;
				try
				{
					int hr = this.filter.EnumPins(out enumPins);
					DsError.ThrowExceptionForHR(hr);

					var pins = new IPin[1];
					while (0 == enumPins.Next(1, pins, IntPtr.Zero))
					{
						T pin = pins[0] as T;
						if (pin != null)
							yield return pin;
						else
							Marshal.ReleaseComObject(pins[0]);
					}
				}
				finally
				{
					if (enumPins != null)
						Marshal.ReleaseComObject(enumPins);
				}
			}

			#endregion IEnumerable<T> Members

			#region IEnumerable Members

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			#endregion IEnumerable Members
		}
	}

	public static class PinUtility
	{
		private class MediaTypeEnum : IEnumerable<AMMediaType>
		{
			private IPin pin;

			public MediaTypeEnum(IPin pin)
			{
				this.pin = pin;
			}

			#region IEnumerable<AMMediaType> Members

			public IEnumerator<AMMediaType> GetEnumerator()
			{
				IEnumMediaTypes enumMediaTypes = null;
				try
				{
					int hr = this.pin.EnumMediaTypes(out enumMediaTypes);
					DsError.ThrowExceptionForHR(hr);

					var mediaTypes = new AMMediaType[1];
					while (0 == enumMediaTypes.Next(1, mediaTypes, IntPtr.Zero))
						yield return mediaTypes[0];
				}
				finally
				{
					if (enumMediaTypes != null)
						Marshal.ReleaseComObject(enumMediaTypes);
				}
			}

			#endregion IEnumerable<AMMediaType> Members

			#region IEnumerable Members

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			#endregion IEnumerable Members
		}
	}
}
