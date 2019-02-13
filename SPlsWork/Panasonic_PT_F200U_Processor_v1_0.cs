using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_PANASONIC_PT_F200U_PROCESSOR_V1_0
{
    public class CrestronModuleClass_PANASONIC_PT_F200U_PROCESSOR_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LAMP_REQUESTED;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_REQUESTED;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_ADJUST;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_PANASONIC_IN;
        Crestron.Logos.SplusObjects.StringInput FROM_DEVICE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput LAMP_HOURS;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_PANASONIC_OUT;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE__DOLLAR__;
        object VOLUME_PANASONIC_IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 123;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOLUME_ADJUST  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 125;
                    MakeString ( TO_DEVICE__DOLLAR__ , "\u0002AVL:{0}\u0003", Functions.ItoA (  (int) ( VOLUME_PANASONIC_IN  .UshortValue ) ) ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object FROM_DEVICE__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 140;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.IBUSYFLAG == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (LAMP_REQUESTED  .Value == 1) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 142;
                _SplusNVRAM.IBUSYFLAG = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 143;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u0003" , FROM_DEVICE__DOLLAR__ ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 145;
                    _SplusNVRAM.STEMP__DOLLAR__  .UpdateValue ( Functions.Remove ( "\u0003" , FROM_DEVICE__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 146;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "ER401" , _SplusNVRAM.STEMP__DOLLAR__ ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( _SplusNVRAM.STEMP__DOLLAR__ ) == 6) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 148;
                        LAMP_HOURS  .Value = (ushort) ( Functions.Atoi( Functions.Mid( _SplusNVRAM.STEMP__DOLLAR__ , (int)( 2 ) , (int)( 4 ) ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 143;
                    } 
                
                __context__.SourceCodeLine = 151;
                _SplusNVRAM.IBUSYFLAG = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 155;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.IBUSYFLAG == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (VOLUME_REQUESTED  .Value == 1) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 157;
                _SplusNVRAM.IBUSYFLAG = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 158;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u0003" , FROM_DEVICE__DOLLAR__ ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 160;
                    _SplusNVRAM.STEMP__DOLLAR__  .UpdateValue ( Functions.Remove ( "\u0003" , FROM_DEVICE__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 161;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "ER401" , _SplusNVRAM.STEMP__DOLLAR__ ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Length( _SplusNVRAM.STEMP__DOLLAR__ ) == 5) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 163;
                        VOLUME_PANASONIC_OUT  .Value = (ushort) ( Functions.Atoi( Functions.Mid( _SplusNVRAM.STEMP__DOLLAR__ , (int)( 2 ) , (int)( 3 ) ) ) ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 158;
                    } 
                
                __context__.SourceCodeLine = 166;
                _SplusNVRAM.IBUSYFLAG = (ushort) ( 0 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 194;
        _SplusNVRAM.IBUSYFLAG = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 195;
        LAMP_HOURS  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 196;
        VOLUME_PANASONIC_OUT  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 197;
        Functions.ClearBuffer ( _SplusNVRAM.STEMP__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 198;
        Functions.ClearBuffer ( FROM_DEVICE__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.STEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
    
    LAMP_REQUESTED = new Crestron.Logos.SplusObjects.DigitalInput( LAMP_REQUESTED__DigitalInput__, this );
    m_DigitalInputList.Add( LAMP_REQUESTED__DigitalInput__, LAMP_REQUESTED );
    
    VOLUME_REQUESTED = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_REQUESTED__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_REQUESTED__DigitalInput__, VOLUME_REQUESTED );
    
    VOLUME_ADJUST = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_ADJUST__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_ADJUST__DigitalInput__, VOLUME_ADJUST );
    
    VOLUME_PANASONIC_IN = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_PANASONIC_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_PANASONIC_IN__AnalogSerialInput__, VOLUME_PANASONIC_IN );
    
    LAMP_HOURS = new Crestron.Logos.SplusObjects.AnalogOutput( LAMP_HOURS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LAMP_HOURS__AnalogSerialOutput__, LAMP_HOURS );
    
    VOLUME_PANASONIC_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_PANASONIC_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_PANASONIC_OUT__AnalogSerialOutput__, VOLUME_PANASONIC_OUT );
    
    FROM_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FROM_DEVICE__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( FROM_DEVICE__DOLLAR____AnalogSerialInput__, FROM_DEVICE__DOLLAR__ );
    
    TO_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__DOLLAR____AnalogSerialOutput__, TO_DEVICE__DOLLAR__ );
    
    
    VOLUME_PANASONIC_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_PANASONIC_IN_OnChange_0, false ) );
    FROM_DEVICE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE__DOLLAR___OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_PANASONIC_PT_F200U_PROCESSOR_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LAMP_REQUESTED__DigitalInput__ = 0;
const uint VOLUME_REQUESTED__DigitalInput__ = 1;
const uint VOLUME_ADJUST__DigitalInput__ = 2;
const uint VOLUME_PANASONIC_IN__AnalogSerialInput__ = 0;
const uint FROM_DEVICE__DOLLAR____AnalogSerialInput__ = 1;
const uint LAMP_HOURS__AnalogSerialOutput__ = 0;
const uint VOLUME_PANASONIC_OUT__AnalogSerialOutput__ = 1;
const uint TO_DEVICE__DOLLAR____AnalogSerialOutput__ = 2;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort IBUSYFLAG = 0;
            [SplusStructAttribute(1, false, true)]
            public CrestronString STEMP__DOLLAR__;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
