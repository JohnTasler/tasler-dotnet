using System;
using System.Runtime.InteropServices;

/////////////////////////////////////////////////////////////////////////////
//// Forward Declarations
//
//interface IMidiManager;

//interface MidiInDevice;
//interface MidiOutDevice;
//interface MidiInDeviceInfo;
//interface MidiOutDeviceInfo;

//interface MidiInChannel;
//interface MidiOutChannel;

//interface MidiInSubscription;

//// Subscription callback interfaces
//interface IMidiInChannelEventsCallback;
//interface IMidiInSystemMessagesCallback;

//interface MidiInDeviceCollection;
//interface MidiOutDeviceCollection;
//interface MidiInChannelCollection;
//interface MidiOutChannelCollection;
//interface MidiInSubscriptionCollection;
//
//
//
///////////////////////////////////////////////////////////////////////////////
//// Enumerations
//
//
//




/////////////////////////////////////////////////////////////////////////////
// Interfaces


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(FF1697E1-C0FF-4EEC-AF89-7A3C2F87B5AA),
	helpstring("IMidiManager Interface"),
	pointer_default(unique)
]
interface IMidiManager : IDispatch
{
	[propget, helpstring("Retrieves the collection of MIDI input devices installed on the system.")]
	HRESULT InputDevices([out, retval] IMidiInDevices** ppDevices);

	[propget, helpstring("Retrieves the collection of MIDI output devices installed on the system.")]
	HRESULT OutputDevices([out, retval] IMidiOutDevices** ppDevices);

	[propget, helpstring("Retrieves a collection of input subscriptions being managed.")]
	HRESULT InputSubscriptions(
		[in, defaultvalue(-1)] VARIANT_BOOL fIncludeDeviceSubscriptions,
		[in, defaultvalue(-1)] VARIANT_BOOL fIncludeChannelSubscriptions,
		[out, retval] IMidiInSubscriptions** ppSubscriptions);

	[helpstring("Converts the specified note name to the corresponding MIDI note number. For example, 'G#3' would be converted to 44.")]
	HRESULT NoteNumberFromName([in] BSTR bstrNoteName, [out, retval] BYTE* pnNoteNumber);

	[helpstring("Converts the specified MIDI note number to a corresponding name. For example, 27 would be converted to 'Eb2'.")]
	HRESULT NoteNameFromNumber([in] BYTE nNoteNumber, [out, retval] BSTR* pbstrNoteName);

}; // End: interface IMidiManager : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(8C069ADC-46A4-43e0-A844-13D38C2AC73B),
	helpstring("IMidiInDevice Interface"),
	pointer_default(unique)
]
interface IMidiInDevice : IDispatch
{
	[propget, helpstring("Retrieves the static information about the MIDI input device.")]
	HRESULT DeviceInfo([out, retval] IMidiInDeviceInfo** ppDeviceInfo);

	[propget, helpstring("Indicates whether or not the device is open.")]
	HRESULT IsOpen([out, retval] VARIANT_BOOL* pfIsOpen);

	[helpstring("Opens the MIDI input device. All properties and methods aside from DeviceInfo and IsOpen will fail when the device is not open. This method does nothing if the device is already open.")]
	HRESULT Open();

	[helpstring("Closes the MIDI input devive. This method does nothing if the device is already closed.")]
	HRESULT Close();

	[helpstring("Starts MIDI input on the MIDI input device.")]
	HRESULT Start();

	[helpstring("Stops input on the MIDI input device.")]
	HRESULT Reset();

	[helpstring("Stops input on the MIDI input device.")]
	HRESULT Stop();

	[propget, helpstring("Retrieves the collection of MIDI ports for the MIDI input device.")]
	HRESULT Channels([out, retval] IMidiInChannels** ppChannels);

	[propget, helpstring("Retrieves the collection of subscriptions to the MIDI input device.")]
	HRESULT Subscriptions([in, defaultvalue(-1)] VARIANT_BOOL fIncludeChannelSubscriptions,
		[out, retval] IMidiInSubscriptions** ppSubscriptions);

	[helpstring("Creates a subscription to all system messages on the device.")]
	HRESULT SubscribeToAllSystemMessages([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'System Exclusive Begin' system messages on the device.")]
	HRESULT SubscribeToSystemExclusiveBegin([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'MTC Quarter Frame' system messages on the device.")]
	HRESULT SubscribeToMTCQuarterFrame([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Song Position Pointer' system messages on the device.")]
	HRESULT SubscribeToSongPositionPointer([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Song Select' system messages on the device.")]
	HRESULT SubscribeToSongSelect([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Tune Request' system messages on the device.")]
	HRESULT SubscribeToTuneRequest([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'SystemExclusiveEnd' system messages on the device.")]
	HRESULT SubscribeToSystemExclusiveEnd([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Timing Clock' system messages on the device.")]
	HRESULT SubscribeToTimingClock([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Start' system messages on the device.")]
	HRESULT SubscribeToStart([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Continue' system messages on the device.")]
	HRESULT SubscribeToContinue([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Stop' system messages on the device.")]
	HRESULT SubscribeToStop([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Active Sensing' system messages on the device.")]
	HRESULT SubscribeToActiveSensing([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Reset' system messages on the device.")]
	HRESULT SubscribeToSystemReset([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

}; // End: interface IMidiInDevice : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(31C4022C-A1D2-4489-9A91-B79119C70C0A),
	helpstring("IMidiInDevices Interface"),
	pointer_default(unique)
]
interface IMidiInDevices : IDispatch
{
	[propget, helpstring("The number of MIDI input devices installed on the system.")]
	HRESULT Count([out, retval] long* pnCount);

	[propget, id(DISPID_NEWENUM), restricted, helpstring("Returns an enumerator object that implements IEnumVARIANT.")]
	HRESULT _NewEnum([out, retval] IUnknown** ppunkEnumVariant);

	[id(DISPID_VALUE), helpstring("Retrieves the specified item, which must be a 1-based index into the collection. An invalid value will return a NULL object.")]
	HRESULT Item([in] VARIANT varIndex, [out, retval] IMidiInDevice** ppItem);

}; // End: interface IMidiInDevices : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(9B54AE24-C4D7-4203-93E1-FEE2B5AE21B4),
	helpstring("IMidiInDeviceInfo Interface"),
	pointer_default(unique)
]
interface IMidiInDeviceInfo : IDispatch
{
	[propget, helpstring("Retrieves the manufacturer identifier of the device driver for the MIDI input device.")]
	HRESULT ManufacturerID([out, retval] short* pnManufacturerID);

	[propget, helpstring("Retrieves the manufacturer name of the device driver for the MIDI input device.")]
	HRESULT ManufacturerName([out, retval] BSTR* pbstrManufacturerName);

	[propget, helpstring("Retrieves the product identifier of the MIDI input device.")]
	HRESULT ProductID([out, retval] short* pnProductID);

	[propget, helpstring("Retrieves the product name of the MIDI input device.")]
	HRESULT ProductName([out, retval] BSTR* pbstrProductName);

	[propget, helpstring("Major version number of the device driver for the MIDI input device.")]
	HRESULT DriverVersionMajor([out, retval] BYTE* pbVersionMajor);

	[propget, helpstring("Minor version number of the device driver for the MIDI input device.")]
	HRESULT DriverVersionMinor([out, retval] BYTE* pbVersionMinor);

}; // End: interface IMidiInDeviceInfo : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(3A0552B0-6F9A-4ae5-8258-A9545E3A1679),
	helpstring("IMidiOutDevice Interface"),
	pointer_default(unique)
]
interface IMidiOutDevice : IDispatch
{
	[propget, helpstring("Retrieves the static information about the MIDI output device.")]
	HRESULT DeviceInfo([out, retval] IMidiOutDeviceInfo** ppDeviceInfo);

	[propget, helpstring("Indicates whether or not the device is open.")]
	HRESULT IsOpen([out, retval] VARIANT_BOOL* pfIsOpen);

	[helpstring("Opens the MIDI output device. All properties and methods aside from DeviceInfo and IsOpen will fail when the device is not open. This method does nothing if the device is already open.")]
	HRESULT Open();

	[helpstring("Closes the MIDI output devive. This method does nothing if the device is already closed.")]
	HRESULT Close();

	[propget, helpstring("Retrieves the collection of MIDI ports for the MIDI output device.")]
	HRESULT Channels([out, retval] IMidiOutChannels** ppChannels);

	[helpstring("Sends the 'System Exclusive Begin' system message.")]
	HRESULT SendSystemExclusiveBegin([in] BYTE nManufacturerID);

	[helpstring("Sends the 'MTC Quarter Frame' system message.")]
	HRESULT SendMTCQuarterFrame([in] BYTE bData1);

	[helpstring("Sends the 'Song Position Pointer' system message.")]
	HRESULT SendSongPositionPointer([in] short nPosition);

	[helpstring("Sends the 'Song Select' system message.")]
	HRESULT SendSongSelect([in] BYTE nSongNumber);

	[helpstring("Sends the 'Tune Request' system message.")]
	HRESULT SendTuneRequest();

	[helpstring("Sends the 'System Exclusive End' system message.")]
	HRESULT SendSystemExclusiveEnd();

	[helpstring("Sends the 'Timing Clock' system message.")]
	HRESULT SendTimingClock();

	[helpstring("Sends the 'Start' system message.")]
	HRESULT SendStart();

	[helpstring("Sends the 'Continue' system message.")]
	HRESULT SendContinue();

	[helpstring("Sends the 'Stop' system message.")]
	HRESULT SendStop();

	[helpstring("Sends the 'Active Sensing' system message.")]
	HRESULT SendActiveSensing();

	[helpstring("Sends the 'Reset' system message.")]
	HRESULT SendSystemReset();

}; // End: interface IMidiOutDevice : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(AD6ACC9F-2855-4592-AEE5-3063D2467968),
	helpstring("IMidiOutDevices Interface"),
	pointer_default(unique)
]
interface IMidiOutDevices : IDispatch
{
	[propget, helpstring("The number of MIDI output devices installed on the system.")]
	HRESULT Count([out, retval] long* pnCount);

	[propget, id(DISPID_NEWENUM), restricted, helpstring("Returns an enumerator object that implements IEnumVARIANT.")]
	HRESULT _NewEnum([out, retval] IUnknown** ppunkEnumVariant);

	[id(DISPID_VALUE), helpstring("Retrieves the specified item, which must be the 1-based index into the collection. An invalid value will return a NULL object.")]
	HRESULT Item([in] VARIANT varIndex, [out, retval] IMidiOutDevice** ppItem);

}; // End: interface IMidiOutDevices : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(CAD7D7F5-F56F-418a-94BA-4FBD7F8539F5),
	helpstring("IMidiOutDeviceInfo Interface"),
	pointer_default(unique)
]
interface IMidiOutDeviceInfo : IDispatch
{
	[propget, helpstring("Retrieves the manufacturer identifier of the device driver for the MIDI output device.")]
	HRESULT ManufacturerID([out, retval] short* pnManufacturerID);

	[propget, helpstring("Retrieves the manufacturer name of the device driver for the MIDI output device.")]
	HRESULT ManufacturerName([out, retval] BSTR* pbstrManufacturerName);

	[propget, helpstring("Retrieves the product identifier of the MIDI output device.")]
	HRESULT ProductID([out, retval] short* pnProductID);

	[propget, helpstring("Retrieves the product name of the MIDI output device.")]
	HRESULT ProductName([out, retval] BSTR* pbstrProductName);

	[propget, helpstring("Major version number of the device driver for the MIDI output device.")]
	HRESULT DriverVersionMajor([out, retval] BYTE* pbVersionMajor);

	[propget, helpstring("Minor version number of the device driver for the MIDI output device.")]
	HRESULT DriverVersionMinor([out, retval] BYTE* pbVersionMinor);

	[propget, helpstring("The technology type of the MIDI output device.")]
	HRESULT TechnologyType([out, retval] MidiOutType* peType);

	[propget, helpstring("The number of voices supported by an internal synthesizer device. If the device is a port, this member is not meaningful and is set to 0.")]
	HRESULT VoiceCount([out, retval] short* pnVoiceCount);

	[propget, helpstring("The maximum number of simultaneous notes that can be played by an internal synthesizer device. If the device is a port, this member is not meaningful and is set to 0.")]
	HRESULT PolyphonyCount([out, retval] short* pnPolyphonyCount);

	[propget, helpstring("Channels that an internal synthesizer device responds to, where the least significant bit refers to channel 0 and the most significant bit to channel 15. Channel devices that transmit on all channels set this member to 0xFFFF.")]
	HRESULT ChannelMask([out, retval] long* pnChannelMask);

	[propget, helpstring("Optional functionality supported by the device.")]
	HRESULT SupportedOptions([out, retval] long* pnSupportedOptions);

}; // End: interface IMidiOutDeviceInfo : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(7E3DC278-9505-413f-A22B-F52EF10EDDA3),
	helpstring("IMidiInChannel Interface"),
	pointer_default(unique)
]
interface IMidiInChannel : IDispatch
{
	[propget, helpstring("Retrieves the top level of the object hierarchy.")]
	HRESULT Manager([out, retval] IMidiManager** ppManager);

	[propget, helpstring("Retrieves the MIDI input device associated with the channel.")]
	HRESULT Device([out, retval] IMidiInDevice** ppDevice);

	[propget, helpstring("Retrieves the MIDI channel number represented by the object. The return value is always the string form of the channel number or 'Omni'.")]
	HRESULT Number([out, retval] BSTR* pbstrNumber);

	[propget, helpstring("Retrieves the collection of subscriptions to the channel.")]
	HRESULT Subscriptions([out, retval] IMidiInSubscriptions** ppSubscriptions);

	[helpstring("Creates a subscription to all MIDI events on the channel.")]
	HRESULT SubscribeToAllEvents([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'Note Off' MIDI events on the channel.")]
	HRESULT SubscribeToNoteOff([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'NoteOn' MIDI events on the channel.")]
	HRESULT SubscribeToNoteOn([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'KeyAftertouch' MIDI events on the channel.")]
	HRESULT SubscribeToKeyAftertouch([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'ControlChange' MIDI events on the channel.")]
	HRESULT SubscribeToControlChange([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'ProgramChange' MIDI events on the channel.")]
	HRESULT SubscribeToProgramChange([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'ChannelAftertouch' MIDI events on the channel.")]
	HRESULT SubscribeToChannelAftertouch([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

	[helpstring("Creates a subscription to 'PitchBend' MIDI events on the channel.")]
	HRESULT SubscribeToPitchBend([in] IUnknown* punkCallback,
		[out, retval] IMidiInSubscription** ppSubscription);

}; // End: interface IMidiInChannel : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(5C177464-806D-4630-A78B-A875522CDC4F),
	helpstring("IMidiInChannels Interface"),
	pointer_default(unique)
]
interface IMidiInChannels : IDispatch
{
	[propget, helpstring("The number of MIDI input channels on the device, plus one for the 'Omni' channel.")]
	HRESULT Count([out, retval] long* pnCount);

	[propget, id(DISPID_NEWENUM), restricted, helpstring("Returns an enumerator object that implements IEnumVARIANT.")]
	HRESULT _NewEnum([out, retval] IUnknown** ppunkEnumVariant);

	[id(DISPID_VALUE), helpstring("Retrieves the specified item, which must be either the one-based index (MIDI channel) into the collection or the 'Omni' string.")]
	HRESULT Item([in] VARIANT varIndex, [out, retval] IMidiInChannel** ppItem);

}; // End: interface IMidiInChannels : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(8617E0F6-050F-41a3-A861-DB630B9729F3),
	helpstring("IMidiOutChannel Interface"),
	pointer_default(unique)
]
interface IMidiOutChannel : IDispatch
{
	[propget, helpstring("Retrieves the top level of the object hierarchy.")]
	HRESULT Manager([out, retval] IMidiManager** ppManager);

	[propget, helpstring("Retrieves the MIDI output device associated with the channel.")]
	HRESULT Device([out, retval] IMidiOutDevice** ppDevice);

	[propget, helpstring("Retrieves the MIDI channel number represented by the object. The return value is always the string form of the channel number.")]
	HRESULT Number([out, retval] BSTR* pbstrNumber);

	[helpstring("Sends the 'Note Off' MIDI event.")]
	HRESULT SendNoteOff([in] BYTE nNoteNumber, [in, defaultvalue(64)] BYTE nNoteVelocity);

	[helpstring("Sends the 'Note On' MIDI event.")]
	HRESULT SendNoteOn([in] BYTE nNoteNumber, [in] BYTE nNoteVelocity);

	[helpstring("Sends the 'Key Aftertouch' MIDI event.")]
	HRESULT SendKeyAftertouch([in] BYTE nNoteNumber, [in] BYTE nAftertouchAmount);

	[helpstring("Sends the 'Control Change' MIDI event.")]
	HRESULT SendControlChange([in] BYTE nController, [in] BYTE nValue);

	[helpstring("Sends the 'Program Change' MIDI event. This must be 1-based (1 through 128)")]
	HRESULT SendProgramChange([in] BYTE nProgramNumber);

	[helpstring("Sends the 'Channel Aftertouch' MIDI event.")]
	HRESULT SendChannelAftertouch([in] BYTE nAftertouchAmount);

	[helpstring("Sends the 'Pitch Bend' MIDI event.")]
	HRESULT SendPitchBend([in] short nValue);

}; // End: interface IMidiOutChannel : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(19849276-BF3A-4a6d-B124-60A561C9F4A7),
	helpstring("IMidiOutChannels Interface"),
	pointer_default(unique)
]
interface IMidiOutChannels : IDispatch
{
	[propget, helpstring("The number of MIDI output channels on the device.")]
	HRESULT Count([out, retval] long* pnCount);

	[propget, id(DISPID_NEWENUM), restricted, helpstring("Returns an enumerator object that implements IEnumVARIANT.")]
	HRESULT _NewEnum([out, retval] IUnknown** ppunkEnumVariant);

	[id(DISPID_VALUE), helpstring("Retrieves the specified item, which must be the one-based index (MIDI channel) into the collection.")]
	HRESULT Item([in] VARIANT varIndex, [out, retval] IMidiOutChannel** ppItem);

}; // End: interface IMidiOutChannels : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(E8E90148-EFDF-4c45-A03E-130C0B33E380),
	helpstring("IMidiInSubscription Interface"),
	pointer_default(unique)
]
interface IMidiInSubscription : IDispatch
{
	[propget, helpstring("Retrieves the subscription type.")]
	HRESULT Type([out, retval] MidiSubscriptionType* peType);

	[propget, helpstring("Retrieves the MIDI event or system message the subscription responds to.")]
	HRESULT Event([out, retval] MidiSubscriptionEvent* peEvent);

	[propget, helpstring("Retrieves the associated input device object. If a channel subscription, the channel's device is returned.")]
	HRESULT InDevice([out, retval] IMidiInDevice** ppDevice);

	[propget, helpstring("Retrieves the associated input channel object, if a channel subscription. Otherwise, NULL is returned.")]
	HRESULT InChannel([out, retval] IMidiInChannel** ppChannel);

	[propget, helpstring("Indicates whether or not the subscription is active. When a subscription is created, it is active until it is destroyed, unless Unsubscribe is called.")]
	HRESULT IsActive([out, retval] VARIANT_BOOL* pfIsActive);

	[helpstring("Cancels the subscription. Following this, IsActive will be false. This method does nothing if the subscription is already inactive. The subscription remains inactive.")]
	HRESULT Unsubscribe();

}; // End: interface IMidiInSubscription : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, dual, uuid(39EA7627-8B15-426e-AAC5-2CDB39A8EA8D),
	helpstring("IMidiInSubscriptions Interface"),
	pointer_default(unique)
]
interface IMidiInSubscriptions : IDispatch
{
	[propget, helpstring("The number of active subscriptions.")]
	HRESULT Count([out, retval] long* pnCount);

	[propget, id(DISPID_NEWENUM), restricted, helpstring("Returns an enumerator object that implements IEnumVARIANT.")]
	HRESULT _NewEnum([out, retval] IUnknown** ppunkEnumVariant);

	[id(DISPID_VALUE), helpstring("Retrieves the specified item, which must be the 1-based index into the collection.")]
	HRESULT Item([in] VARIANT varIndex, [out, retval] IMidiInSubscription** ppItem);

}; // End: interface IMidiInSubscriptions : IDispatch


/////////////////////////////////////////////////////////////////////////////
//
[
	object, oleautomation, uuid(40B0D89D-85C7-4d9e-83A6-61165938D92A),
	helpstring("IMidiInChannelEventsCallback Interface"),
	pointer_default(unique)
]
interface IMidiInChannelEventsCallback : IUnknown
{
	HRESULT OnAllEvents([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE bStatus, [in] BYTE bData1, [in] BYTE bData2);
	HRESULT OnNoteOff([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nNoteNumber, [in] BYTE nNoteVelocity);
	HRESULT OnNoteOn([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nNoteNumber, [in] BYTE nNoteVelocity);
	HRESULT OnKeyAftertouch([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nNoteNumber, [in] BYTE nAftertouchAmount);
	HRESULT OnControlChange([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nController, [in] BYTE nValue);
	HRESULT OnProgramChange([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nProgramNumber);
	HRESULT OnChannelAftertouch([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] BYTE nAftertouchAmount);
	HRESULT OnPitchBend([in] IMidiInChannel* pChannel, [in] long nTimeStamp,
		[in] short nValue);

}; // End: interface IMidiInChannelEventsCallback : IUnknown


/////////////////////////////////////////////////////////////////////////////
//
[
	object, oleautomation, uuid(1B3F654B-B274-4e20-94D3-14B563B62F9F),
	helpstring("IMidiInSystemMessagesCallback Interface"),
	pointer_default(unique)
]
interface IMidiInSystemMessagesCallback : IUnknown
{
	HRESULT OnAllSystemMessages([in] BYTE bStatus, [in] BYTE bData1, [in] BYTE bData2);
	HRESULT OnSystemExclusiveBegin([in] BYTE nManufacturerID);
	HRESULT OnMTCQuarterFrame([in] BYTE bData1);
	HRESULT OnSongPositionPointer([in] short nPosition);
	HRESULT OnSongSelect([in] BYTE nSongNumber);
	HRESULT OnTuneRequest();
	HRESULT OnSystemExclusiveEnd();
	HRESULT OnTimingClock();
	HRESULT OnStart();
	HRESULT OnContinue();
	HRESULT OnStop();
	HRESULT OnActiveSensing();
	HRESULT OnSystemReset();

}; // End: interface IMidiInSystemMessagesCallback : IUnknown


/////////////////////////////////////////////////////////////////////////////
//
[
	uuid(1957D65D-3308-434B-A9B1-3F939D9795EE),
	version(1.0),
	helpstring("MidiCom 1.0 Type Library")
]
library MidiComLib
{
	importlib("stdole32.tlb");
	importlib("stdole2.tlb");


	/////////////////////////////////////////////////////////////////////////
	// Reference the non-referenced interfaces to get them into typelib.
	// Subscription callback interfaces
	interface IMidiInChannelEventsCallback;
	interface IMidiInSystemMessagesCallback;


	/////////////////////////////////////////////////////////////////////////
	//
	[
		uuid(CD24E204-20DD-4BEE-91ED-DD3CE0740EA3),
		helpstring("MidiManager Class")
	]
	coclass MidiManager
	{
		[default] interface IMidiManager;
	};

}; // End: library MidiComLib

