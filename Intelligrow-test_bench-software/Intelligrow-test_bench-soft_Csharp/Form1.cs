
using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;       // Pour utiliser le port serie
using System.Threading;
using System.Threading.Tasks;

namespace Intelligrow_test_bench_soft_Csharp
{
    public partial class Form1 : Form
    {
        //const string DllPath = ".\\mcp2210_dll_um_x86.dll";
        const string DllPath = "C:\\Users\\jeanf\\Desktop\\git\\Intelligrow-test_bench\\Library\\mcp2210_dll_um_x86.dll";

        /* API for getting access to the USB device */
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetLibraryVersion", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetLibraryVersion(StringBuilder version);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetLastError", CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetLastError();
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetConnectedDevCount", CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetConnectedDevCount(ushort vid, ushort pid);
        [DllImport(DllPath, EntryPoint = "Mcp2210_OpenByIndex", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Mcp2210_OpenByIndex(ushort vid, ushort pid, uint index, StringBuilder devPath, ref ulong devPathsize);
        [DllImport(DllPath, EntryPoint = "Mcp2210_OpenBySN", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Mcp2210_OpenBySN(ushort vid, ushort pid, String serialNo, StringBuilder devPath, ref ulong devPathsize);
        [DllImport(DllPath, EntryPoint = "Mcp2210_Close", CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_Close(IntPtr handle);
        [DllImport(DllPath, EntryPoint = "Mcp2210_Reset", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_Reset(IntPtr handle);

        /* USB settings */
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetUsbKeyParams", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetUsbKeyParams(IntPtr handle, ref ushort pvid, ref ushort ppid,
                                                         ref byte ppwrSrc, ref byte prmtWkup, ref ushort pcurrentLd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetUsbKeyParams", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetUsbKeyParams(IntPtr handle, ushort vid, ushort pid,
                                                         byte pwrSrc, byte rmtWkup, ushort currentLd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetManufacturerString", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetManufacturerString(IntPtr handle, StringBuilder manufacturerStr);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetManufacturerString", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetManufacturerString(IntPtr handle, String manufacturerStr);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetProductString", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetProductString(IntPtr handle, StringBuilder productStr);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetProductString", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetProductString(IntPtr handle, String productStr);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetSerialNumber", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetSerialNumber(IntPtr handle, StringBuilder serialStr);

        /* API to access GPIO settings and values */
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetGpioPinDir", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetGpioPinDir(IntPtr handle, ref uint pgpioDir);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetGpioPinDir", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetGpioPinDir(IntPtr handle, uint gpioSetDir);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetGpioPinVal", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetGpioPinVal(IntPtr handle, ref uint pgpioPinVal);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetGpioPinVal", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetGpioPinVal(IntPtr handle, uint gpioSetVal, ref uint pgpioPinVal);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetGpioConfig", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetGpioConfig(IntPtr handle, byte cfgSelector, byte[] pGpioPinDes, ref uint pdfltGpioOutput,
                                                        ref uint pdfltGpioDir, ref byte prmtWkupEn, ref byte pintPinMd, ref byte pspiBusRelEn);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetGpioConfig", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetGpioConfig(IntPtr handle, byte cfgSelector, byte[] pGpioPinDes, uint dfltGpioOutput,
                                                        uint dfltGpioDir, byte rmtWkupEn, byte intPinMd, byte spiBusRelEn);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetInterruptCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetInterruptCount(IntPtr handle, ref uint pintCnt, byte reset);

        /* API to control SPI transfer */
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetSpiConfig", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetSpiConfig(IntPtr handle, byte cfgSelector, ref uint pbaudRate, ref uint pidleCsVal,
                                                        ref uint pactiveCsVal, ref uint pcsToDataDly, ref uint pdataToCsDly,
                                                        ref uint pdataToDataDly, ref uint ptxferSize, ref byte pspiMd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetSpiConfig", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetSpiConfig(IntPtr handle, byte cfgSelector, ref uint pbaudRate, ref uint pidleCsVal,
                                                        ref uint pactiveCsVal, ref uint pcsToDataDly, ref uint pdataToCsDly,
                                                        ref uint pdataToDataDly, ref uint ptxferSize, ref byte pspiMd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_xferSpiData", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_xferSpiData(IntPtr handle, byte[] pdataTx, byte[] pdataRx,
                                                        ref uint pbaudRate, ref uint ptxferSize, uint csmask);
        [DllImport(DllPath, EntryPoint = "Mcp2210_xferSpiDataEx", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_xferSpiDataEx(IntPtr handle, byte[] pdataTx, byte[] pdataRx,
                                                        ref uint pbaudRate, ref uint ptxferSize, uint csmask,
                                                        ref uint pidleCsVal, ref uint pactiveCsVal, ref uint pCsToDataDly,
                                                        ref uint pdataToCsDly, ref uint pdataToDataDly, ref byte pspiMd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_CancelSpiTxfer", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_CancelSpiTxfer(IntPtr handle, ref byte pspiExtReqStat, ref byte pspiOwner);
        [DllImport(DllPath, EntryPoint = "Mcp2210_RequestSpiBusRel", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_RequestSpiBusRel(IntPtr handle, byte ackPinVal);
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetSpiStatus", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetSpiStatus(IntPtr handle, ref byte pspiExtReqStat, ref byte pspiOwner, ref byte pspiTxferStat);

        /* EEPROM read/write API */
        [DllImport(DllPath, EntryPoint = "Mcp2210_ReadEEProm", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_ReadEEProm(IntPtr handle, byte address, ref byte pcontent);
        [DllImport(DllPath, EntryPoint = "Mcp2210_WriteEEProm", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_WriteEEProm(IntPtr handle, byte address, byte content);

        /* Access control API */
        [DllImport(DllPath, EntryPoint = "Mcp2210_GetAccessCtrlStatus", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_GetAccessCtrlStatus(IntPtr handle, ref byte pAccessCtrl, ref byte pPasswdAttemptCnt, ref byte pPasswdAccepted);
        [DllImport(DllPath, EntryPoint = "Mcp2210_EnterPassword", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_EnterPassword(IntPtr handle, String passwd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetAccessControl", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetAccessControl(IntPtr handle, byte accessConfig, String currentPasswd, String newPasswd);
        [DllImport(DllPath, EntryPoint = "Mcp2210_SetPermanentLock", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Mcp2210_SetPermanentLock(IntPtr handle);

        /**** Constants ****/
        public const ushort DEFAULT_VID = 0x4d8;
        public const ushort DEFAULT_PID = 0xde;

        // GPIO Pin Designation
        public const byte MCP2210_PIN_DES_GPIO = 0; /* pin configured as GPIO */
        public const byte MCP2210_PIN_DES_CS = 1;   /* pin configured as chip select - CS */
        public const byte MCP2210_PIN_DES_FN = 2;   /* pin configured as dedicated function pin */

        // VM/NVRAM selection - use it as cfgSelector parameter
        public const byte MCP2210_VM_CONFIG = 0;    /* designates current chip setting - Volatile Memory */
        public const byte MCP2210_NVRAM_CONFIG = 1; /* designates power-up chip setting - NVRAM          */

        // remote wake-up enable/disable
        public const byte MCP2210_REMOTE_WAKEUP_ENABLED = 1;
        public const byte MCP2210_REMOTE_WAKEUP_DISABLED = 0;

        // interrupt counting mode
        public const byte MCP2210_INT_MD_CNT_HIGH_PULSES = 4;
        public const byte MCP2210_INT_MD_CNT_LOW_PULSES = 3;
        public const byte MCP2210_INT_MD_CNT_RISING_EDGES = 2;
        public const byte MCP2210_INT_MD_CNT_FALLING_EDGES = 1;
        public const byte MCP2210_INT_MD_CNT_NONE = 0;

        // SPI bus release enable/disable
        public const byte MCP2210_SPI_BUS_RELEASE_ENABLED = 0;
        public const byte MCP2210_SPI_BUS_RELEASE_DISABLED = 1;

        // SPI bus release ACK pin value
        public const byte MCP2210_SPI_BUS_RELEASE_ACK_LOW = 0;
        public const byte MCP2210_SPI_BUS_RELEASE_ACK_HIGH = 1;

        // SPI Mode selection
        public const byte MCP2210_SPI_MODE0 = 0;
        public const byte MCP2210_SPI_MODE1 = 1;
        public const byte MCP2210_SPI_MODE2 = 2;
        public const byte MCP2210_SPI_MODE3 = 3;

        // GP8 firmware error workaround bit
        public const UInt32 MCP2210_GP8CE_MASK = 0x80000000;               

        /**** Error codes ****/
        public const int E_SUCCESS = 0;
        public const int E_ERR_INVALID_PARAMETER = -2;
        public const int E_ERR_BUFFER_TOO_SMALL = -3;
        public const int E_ERR_NULL = -10;
        public const int E_ERR_INVALID_HANDLE_VALUE = -30;
        public const int E_ERR_NO_SUCH_INDEX = -101;
        public const int E_ERR_CONNECTION_ALREADY_OPENED = -106;
        public const int E_ERR_CLOSE_FAILED = -107;
        public const int E_ERR_NO_SUCH_SERIALNR = -108;
        public const int E_ERR_HID_RW_FILEIO = -111;

        public const int E_ERR_SPI_EXTERN_MASTER = -204;
        public const int E_ERR_SPI_TIMEOUT = -205;
        public const int E_ERR_SPI_XFER_ONGOING = -207;

        public const int E_ERR_BLOCKED_ACCESS = -300;
        public const int E_ERR_NVRAM_LOCKED = -350;
        public const int E_ERR_WRONG_PASSWD = -351;
        public const int E_ERR_ACCESS_DENIED = -352;
        public const int E_ERR_NVRAM_PROTECTED = -353;
        public const int E_ERR_PASSWD_CHANGE = -354;

        public const int E_ERR_STRING_TOO_LARGE = -401;

        byte[] gpioPinDes = { 0, 0, 0, 2, 0, 0, 0, 0, 0 };  // Pin designator array, define pin mode (GP0...GP8)
        byte device_opened = 0;                             // Variable indicated wether a device was opened or not            
        IntPtr MCP2210_deviceHandle = new IntPtr();         // MCP2210 Device handle
        ulong pathSize = 0;                                 // Defined but not used by application
        StringBuilder path = new StringBuilder();           // Defined but not used by application
        int res;                                            // MCP2210 result output, used for error checking
        uint gpiopinval = 0x01A8;
        // set the SPI xfer params for I/O expander
        uint usb_spi_baudrate = 10000000;                    // mbps
        uint usb_spi_idle_cs = 0xFFFFFFFF;                       // 
        uint usb_spi_active_cs = 0xFFFFFFFF;                     // GP4,GP2,GP1 and GP0 set as active low CS
        uint usb_spi_cs2data_delay = 0;                     // #CS to data delay
        uint usb_spi_data2data_delay = 0;                   // data to data delay
        uint usb_spi_data2cs_delay = 0;                     // data to #CS delay
        uint usb_spi_txfer_size = 3;                        // Transfer size, interchangeable per transfer
        byte usb_spi_mode = 0;                              // SPI mode 0        

        //------------------------------------------------------------------------------//
        // Intelligrow test bench variable and constants definition
        // USB-SPI bridge port configuration
        // GP0 - ADC_#CS            -- CS,      SPI ADC MCP3208
        // GP1 = EXP_#CS            -- CS,      IO expander 8bit
        // GP2 = USB_SPI_#CS        -- CS,      FT8XX EVE multiplexer, FT8XX USB controlled SPI port, #CS
        // GP3 = SPI_TRAFIC_LED     -- AFN,     Dedicated function, SPI traffic LED    
        // GP4 = DAC_#CS            -- CS,      SPI DAC MCP4922
        // GP5 = EVE_SIG_SEL        -- GPIO,    FT8XX EVE multiplexer, route signals from either Intelligrow PCB or test bench SPI bridge
        // GP6 = USB_SPI_#IN        -- GPIO,    FT8XX EVE multiplexer, FT8XX USB controller SPI port, interrupt input
        // GP7 = USB_SPI_#PD        -- GPIO,    FT8XX EVE multiplexer, FT8XX USB controller SPI port, Power down output
        // GP8 = SENSOR_SRC_SEL     -- GPIO,    Test bench multiplexer, route Moist / Light sensor signal from either Intelligrow PCB or test bench DAC
        // Definition of SPI #CS bits for masking
        public const UInt16 MCP3208 = 0xFFE;                      // Define MCP3208 as GP0 CS
        public const UInt16 MCP23S08 = 0xFFD;                     // Define MCP23S08 as GP1 CS
        public const UInt16 FT8XX = 0xFFB;                        // Define FT8XX as GP2 CS
        public const UInt16 MCP4922 = 0xFEF;                      // Define MCP4922 as GP3 CS
        
        // SPI ADC configuration and variables ------------------------------------------
        struct SPI_ADC_MCP3208 
        {
            public UInt16 DUT_vin_monitor;
            public UInt16 DUT_load_current_sense;
            public UInt16 DUT_moisture_sense;
            public UInt16 DUT_vfeedback_sense;
            public UInt16 DUT_temperature_sense;
            public UInt16 DUT_3V3_sense;
            public UInt16 DUT_rtc_battery_sense;
            public UInt16 DUT_light_sense;
        }
        SPI_ADC_MCP3208 struct_mcp3208;
        public const byte ADC_CH0 = 0;
        public const byte ADC_CH1 = 1;
        public const byte ADC_CH2 = 2;
        public const byte ADC_CH3 = 3;
        public const byte ADC_CH4 = 4;
        public const byte ADC_CH5 = 5;
        public const byte ADC_CH6 = 6;
        public const byte ADC_CH7 = 7;
        public const UInt16 adc_default_write = 0xC000;
        public const double ADC_v_p_lsb = 0.00080566;
        public const double VIN_monitor_ratio = 0.180831;      // Ratio is 10k / (10k + 45k3)
        public const UInt16 CURRENT_sense_gain = 1460;
        public const double CURRENT_sense_resistor = 2200;

        // SPI DAC configuration and variables
        struct SPI_DAC_MCP4922
        {
            public UInt16 DAC_outa;
            public UInt16 DAC_outb;
        }
        SPI_DAC_MCP4922 struct_mcp4922;
        public const byte DAC_OUTA = 0;
        public const byte DAC_OUTB = 1;

        // IO Expander configuration, variables and register definitions --------------------------------
        // SPI IO expander port configuration
        // GP0 - LIGHT_CTRL_IN                              -- Input of light control signal
        // GP1 = PUMP_CTRL_IN                               -- Input of pump control signal
        // GP2 = LIGHT_GATE_IN                              -- Input of inversed light control signal
        // GP3 = PUMP_GATE_IN                               -- Input of inversed pump control signal 
        // GP4 = 12V_DUT_EN                                 -- DUT load switch enable output (active high)
        // GP5 = RGB_LED_R                                  -- RGB LED Red LED (active low)
        // GP6 = RGB_LED_G                                  -- RGB LED Green LED (active low)
        // GP7 = RGB_LED_B                                  -- RGB LED Blue LED (active low)
        struct SPI_EXPANDER_MCP23S08
        {
            public byte default_port_output;
            public byte default_port_mapping;
            public byte actual_port_output;
        }
        SPI_EXPANDER_MCP23S08 struct_mcp23s08;
        public const byte MCP23S08_ADR = 0x46;              // Fixed hardware address
        public const byte IODIR = 0x0;                      // Set IO direction as either input or output
        public const byte IPOL = 0x1;                       // Set interrupt polarity on pins
        public const byte GPINTEN = 0x2;                    // Set interrupt on change on pins
        public const byte DEFVAL = 0x3;                     // Setup default value compare
        public const byte INTCON = 0x4;                     // Setup interrupt control
        public const byte IOCON = 0x5;                      // Setup IO control
        public const byte GPPU = 0x6;                       // Setup pull-up on pins
        public const byte INTF = 0x7;                       // Read interrupt flag on pin
        public const byte INTCAP = 0x8;                     // Read interrupt capture value
        public const byte GPIO = 0x9;                       // Read value of GPIO port
        public const byte OLAT = 0xA;                       // Set value of output latch
        public const byte DUT_EN_ON = 0x10;
        public const byte DUT_EN_OFF = 0xEF;
        public const byte RGBLED_RED_ON = 0xDF;
        public const byte RGBLED_GREEN_ON = 0xBF;
        public const byte RGBLED_BLUE_ON = 0x7F;
        public const byte RGBLED_YELLOW_ON = 0x9F;
        public const byte RGBLED_WHITE_ON = 0x1F;
        public const byte RGBLED_CYAN_ON = 0x3F;
        public const byte RGBLED_PURPLE_ON = 0x5F;
        public const byte RGBLED_ALL_OFF = 0xE0;
        public const byte RGBLED_RED = 0;
        public const byte RGBLED_GREEN = 1;
        public const byte RGBLED_BLUE = 2;
        public const byte RGBLED_YELLOW = 3;
        public const byte RGBLED_WHITE = 4;
        public const byte RGBLED_CYAN = 5;
        public const byte RGBLED_PURPLE = 6;
        public const byte RGBLED_OFF = 7;


        // ------------------------------------------------------------------------------
        // Application-related variables
        public byte ADC_timer_flag = 0;
        public byte RGBLED_blink_flag = 0;
        public byte ADC_actual_channel = 0;
        public byte RGBLED_actual_color = RGBLED_OFF;
        public UInt16 ms_counter = 0;
        public byte color_counter = 0;
        public double temp_coeff = 0.01;
        public double temp_offset = 0.5;

        // State machine states
        Int16 state_machine = -1;
        public const byte INITIALIZE_MCP2210 = 0;
        public const byte INITIALIZE_MCP23S08 = 1;
        public const byte INITIALIZE_MCP2221A = 2;
        public const byte INITIALIZE_CP2102N = 3;
        public const byte ACTIVATE_DUT = 4;
        public const byte DEACTIVATE_DUT = 5;

        public const byte STOP_TEST = 253;
        public const byte TEST_STATE_IDLE = 254;
        public const byte ERROR_HANDLER = 255;
        


        // Variables de test
        UInt16 DAC_data = 0;
        public Form1()
        {
            InitializeComponent();

            Start_test_button.Enabled = true;               // Default Start test button value = enabled
            Stop_test_button.Enabled = false;               // Default Stop test button value = disabled
            stop_on_fail_CheckBox.Checked = true;           // Stop on fail default value = true, stop on a fail
            save_log_CheckBox.Checked = true;               // Save log file default value = true, save log file

            Log_rtf.Text = "Test bench program for the #Intelligrow garden";
            Log_rtf.Text += "\nPress the Start test button to start the test sequence";

            struct_mcp23s08.default_port_output = 0xEF;
            struct_mcp23s08.default_port_mapping = 0x0F;

            struct_mcp23s08.actual_port_output = struct_mcp23s08.default_port_output;
            struct_mcp4922.DAC_outa = 0x000;
            struct_mcp4922.DAC_outb = 0x000;

            try                                                     // Look if any peripheral is identified as a serial port
            {
                string[] ListePorts = SerialPort.GetPortNames();
                CP2102n_port_ComboBox.Items.AddRange(ListePorts);
                CP2102n_port_ComboBox.SelectedIndex = 1;
            }
            catch
            {
                CP2102n_port_ComboBox.Items.AddRange(new string[] { "" });
            }

            RGBLED_blink_timer.Enabled = false;
            ADC_timer.Enabled = false;
        }

        // ---------------------------------------------------------------------------------------------- //
        // ---------------------------- Test bench state machine - sets flow ---------------------------- //

        private void Main_timer_Tick(object sender, EventArgs e)
        {
            ADC_scan_channels();
            switch (state_machine)
            {
                case TEST_STATE_IDLE:
                    break;

                case INITIALIZE_MCP2210:
                    Log_rtf.Text += "\nState is : INITIALIZE_MCP2210";
                    state_machine = INITIALIZE_MCP23S08;

                    if (MCP2210_initialize() == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }   
                    
                    break;

                case INITIALIZE_MCP23S08:
                    Log_rtf.Text += "\nState is : INITIALIZE_MCP23S08";
                    state_machine = INITIALIZE_MCP2221A;

                    if (MCP23S08_initialize() == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }

                    if (RGBLED_set_color(RGBLED_WHITE) == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }
                    
                    break;

                case INITIALIZE_MCP2221A:
                    Log_rtf.Text += "\nState is : INITIALIZE_MCP2221A";
                    state_machine = INITIALIZE_CP2102N;

                    break;

                case INITIALIZE_CP2102N:
                    Log_rtf.Text += "\nState is : INITIALIZE_CP2102N";
                    state_machine = ACTIVATE_DUT;

                    break;

                case ACTIVATE_DUT:
                    Log_rtf.Text += "\nState is : ACTIVATE_DUT";
                    state_machine = TEST_STATE_IDLE;
                    
                    if (DUT_enable() == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }
                    else
                    {
                        ADC_timer.Enabled = true;
                        RGBLED_blink_timer.Enabled = true;
                        RGBLED_actual_color = RGBLED_YELLOW;
                    }
                    break;

                case DEACTIVATE_DUT:
                    Log_rtf.Text += "\nState is : DEACTIVATE_DUT";
                    state_machine = TEST_STATE_IDLE;
                    ADC_timer.Enabled = false;

                    if (DUT_disable() == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }
                                     
                    break;

                case STOP_TEST:
                    Log_rtf.Text += "\nState is : STOP_TEST";
                    state_machine = TEST_STATE_IDLE;
                    RGBLED_blink_timer.Enabled = false;
                    ADC_timer.Enabled = false;
                    Main_timer.Enabled = false;

                    // Power-off the DUT
                    if (DUT_disable() == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }

                    // Turn off the test sequence LED
                    if (RGBLED_set_color(RGBLED_OFF) == -1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }

                    // Release the handle associated with the MCP2210
                    if (MCP2210_disconnect() == 1)
                    {
                        if (stop_on_fail_CheckBox.Checked == true)
                        {
                            state_machine = ERROR_HANDLER;
                        }
                    }

                    break;

                case ERROR_HANDLER:
                    state_machine = TEST_STATE_IDLE;
                    Log_rtf.Text += "\nState is : ERROR_HANDLER";
                    Log_rtf.Text += "\nError was detected during execution";

                    Main_timer.Enabled = false;
                    ADC_timer.Enabled = false;
                    
                    Start_test_button.Enabled = true;
                    Stop_test_button.Enabled = false;                 
                    break;
            }
        }
        // ---------------------------------------------------------------------------------------------- //


        // ---------------------------- Test bench hardware access functions ---------------------------- //
        private int MCP2210_initialize ()
        {
            int devCount = Mcp2210_GetConnectedDevCount(DEFAULT_VID, DEFAULT_PID);
            if (devCount > 0)   // Check wether there is a MCP2210 connected or not
            {
                // Get the device handle before intializing the device with the default configuration
                MCP2210_deviceHandle = Mcp2210_OpenByIndex(DEFAULT_VID, DEFAULT_PID, 0, path, ref pathSize); //try to open the first device
                res = Mcp2210_GetLastError();
                if (res != E_SUCCESS)
                {
                    Log_rtf.Text += "\nCould not open the connection to the MCP2210. Verify it is properly plugged in the USB port.";
                    Log_rtf.Text += "\n The error code is : ";
                    Log_rtf.Text += Convert.ToString(res);
                    // Handle the error
                    return -1;
                }
                Console.WriteLine("MCP2210 successfully opened");

                res = Mcp2210_SetGpioPinDir(MCP2210_deviceHandle, 0x040);
                if (res != E_SUCCESS)
                {
                    Log_rtf.Text += "\nThere was an error in the Mcp2210_SetGpioPinDir function";
                    Log_rtf.Text += "\nThe error code is : ";
                    Log_rtf.Text += Convert.ToString(res);
                    // Handle the error
                    return -1;
                }

                res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, 0x01FF, ref gpiopinval);
                if (res != E_SUCCESS)
                {
                    Log_rtf.Text += "\nThere was an error in the Mcp2210_SetGpioPinVal function";
                    Log_rtf.Text += "\nThe error code is : ";
                    Log_rtf.Text += Convert.ToString(res);
                    // Handle the error
                    return -1;
                }

                res = Mcp2210_SetGpioConfig(MCP2210_deviceHandle, MCP2210_VM_CONFIG, gpioPinDes, 1, 0, MCP2210_REMOTE_WAKEUP_DISABLED, MCP2210_INT_MD_CNT_NONE, MCP2210_SPI_BUS_RELEASE_DISABLED);
                if (res != E_SUCCESS)
                {
                    Log_rtf.Text += "\nThere was an error in the Mcp2210_SetGpioConfig function";
                    Log_rtf.Text += "\nThe error code is : ";
                    Log_rtf.Text += Convert.ToString(res);
                    // Handle the error
                    return -1;
                }

                res = Mcp2210_SetSpiConfig(MCP2210_deviceHandle, MCP2210_VM_CONFIG, ref usb_spi_baudrate, ref usb_spi_idle_cs, ref usb_spi_active_cs, ref usb_spi_cs2data_delay, ref usb_spi_data2data_delay, ref usb_spi_data2cs_delay,
                    ref usb_spi_txfer_size, ref usb_spi_mode);
                if (res != E_SUCCESS)
                {
                    Log_rtf.Text += "\nThere was an error in the Mcp2210_SetSpiConfig function";
                    Log_rtf.Text += "\nThe error code is : ";
                    Log_rtf.Text += Convert.ToString(res);
                    // Handle the error
                    return -1;
                }

                MCP23S08_write_byte(MCP23S08_ADR, IODIR, struct_mcp23s08.default_port_mapping);
                MCP23S08_write_byte(MCP23S08_ADR, OLAT, struct_mcp23s08.default_port_output);

                Log_rtf.Text += "\nMCP2210 successfully configured";

                device_opened = 1;
                return 0;
            }

            else
            {
                Log_rtf.Text += "\nNo MCP2210 device found";
                return -1;
            }
        }

        private int MCP23S08_initialize()
        {
            if (MCP23S08_write_byte(MCP23S08_ADR, IODIR, struct_mcp23s08.default_port_mapping) == -1) { return -1; }
            if (MCP23S08_write_byte(MCP23S08_ADR, OLAT, struct_mcp23s08.default_port_output) == -1) { return -1; }
            return 0;
        }

        private int MCP2210_disconnect()
        {
            int res = Mcp2210_Close(MCP2210_deviceHandle);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_Close function";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += Convert.ToString(res);
                // Handle the error
                return 1;
            }
            else
            {
                Log_rtf.Text += "\nMCP2210 successfully closed";
                return 0;
            }  
        }

        private int DUT_enable ()
        {
            if (device_opened == 1)
            {
                struct_mcp23s08.actual_port_output = Convert.ToByte(struct_mcp23s08.actual_port_output | DUT_EN_ON);
                if (MCP23S08_write_byte(MCP23S08_ADR, OLAT, struct_mcp23s08.actual_port_output) == -1) { return -1; }
                return 0;
            }
            else
                return -1;
        }

        private int DUT_disable ()
        {
            if (device_opened == 1)
            {
                struct_mcp23s08.actual_port_output = Convert.ToByte(struct_mcp23s08.actual_port_output & DUT_EN_OFF);
                if (MCP23S08_write_byte(MCP23S08_ADR, OLAT, 0xEF) == -1) { return -1; }
                return 0;
            }
            else
                return -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close the application? Selecting <<Yes>> will disable the DUT and close the handles to the USB bridges.", "Closing software?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //ouvre un dialogBox et demande la fermeture de l'application
            if (result == DialogResult.No)
            {
                e.Cancel = true;             //Resultat negatif, ne ferme pas
            }
            else
            {
                if (device_opened == 1)
                {
                    MCP23S08_write_byte(MCP23S08_ADR, OLAT, 0xEF);
                    res = Mcp2210_Close(MCP2210_deviceHandle);
                    if (res != E_SUCCESS)
                    {
                        Log_rtf.Text += "\nThere was an error in the Mcp2210_Close function";
                        Log_rtf.Text += "\nThe error code is : ";
                        Log_rtf.Text += res;
                        // Handle the error
                        return;
                    }
                    else
                    {
                        Log_rtf.Text += "\nHardware successfully closed to a safe state";
                    }
                }
                else
                {
                    Log_rtf.Text += "\nHardware successfully closed to a safe state";
                }
                
                e.Cancel = false;            
            }
        }


        private int MCP23S08_read_byte(byte address, byte register)
        {
            uint spi_txfer_size = 3;
            byte read_address = Convert.ToByte(address | 0x01);
            byte[] MCP23S08_io_value = { read_address, register, 0};
            byte[] MCP23S08_rx_data = { 0, 0, 0 };

            if (SPI_enable_cs(MCP23S08) == -1)
            {
                return -1;
            }

            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP23S08_io_value, MCP23S08_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_xferSpiData function while setting the output values of the IO expander";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            if (SPI_disable_cs(MCP23S08) == -1)
            {
                return -1;
            }
            return MCP23S08_rx_data[2]; // Return the value of the requested register
        }

        private int MCP23S08_write_byte (byte address, byte register, byte value)
        {
            uint spi_txfer_size = 3;
            byte[] MCP23S08_io_value = { address, register, value };
            byte[] MCP23S08_rx_data = { 0, 0, 0 };

            if (SPI_enable_cs(MCP23S08) == -1)
            {
                return -1;
            }

            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP23S08_io_value, MCP23S08_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_xferSpiData function while setting the output values of the IO expander";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            if (SPI_disable_cs(MCP23S08) == -1)
            {
                return -1;
            }

            return 0;
        }

        private int MCP4922_write_output (byte channel, UInt16 value)
        {
            uint spi_txfer_size = 2;
            byte[] MCP4922_io_value = { 0, 0};
            byte[] MCP4922_rx_data = { 0, 0};
            UInt16 output_word;

            if (value > 0xFFF) { value = 0xFFF; }
            switch (channel)
            {
                case DAC_OUTA:
                    output_word = Convert.ToUInt16(0x7000 | value);
                    MCP4922_io_value[0] = Convert.ToByte(((output_word & 0xFF00) >> 8));
                    MCP4922_io_value[1] = Convert.ToByte(output_word & 0x00FF);
                    break;

                case DAC_OUTB:
                    output_word = Convert.ToUInt16(0xF000 | value);
                    MCP4922_io_value[0] = Convert.ToByte(((output_word & 0xFF00) >> 8));
                    MCP4922_io_value[1] = Convert.ToByte(output_word & 0x00FF);
                    break;

                default:
                    break;
            }

            if (SPI_enable_cs(MCP4922) == -1) {return -1;}

            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP4922_io_value, MCP4922_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_xferSpiData function while setting the output values of the DAC";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            if (SPI_disable_cs(MCP4922) == -1){ return -1; }

            return 0;
        }

        private int MCP3208_read_channel (byte channel)
        {
            uint spi_txfer_size = 3;
            byte tx_data_0 = Convert.ToByte(0x06 | ((channel & 0x04) >> 2));
            byte tx_data_1 = Convert.ToByte((channel & 0x03) << 6);
            byte[] MCP3208_io_value = { tx_data_0, tx_data_1, 0xFF};
            byte[] MCP3208_rx_data = { 0, 0 , 0};

            if (SPI_enable_cs(MCP3208) == -1){ return -1; }

            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP3208_io_value, MCP3208_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_xferSpiData function while setting the output values of the ADC";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            if (SPI_disable_cs(MCP3208) == -1) { return -1; }
            UInt16 output_word = Convert.ToUInt16(((MCP3208_rx_data[1] << 8) | MCP3208_rx_data[2])&0x0FFF);
            return output_word;
        }

        //--------------------------------------------------------------------//
        // SPI #CS workaround to prevent GPIO toggling / changing state during
        // actual SPI transfers
        private int SPI_enable_cs(uint device)
        {
            uint gpioDefVal = 0x1FF;  // Default value = all pins high
            uint gpiopinval = 0;

            gpioDefVal = gpioDefVal & device;

            res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, gpioDefVal, ref gpiopinval);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_SetGpioPinVal function during SPI_enable_cs call";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            return 0;
        }

        private int SPI_disable_cs(uint device)
        {
            uint gpioDefVal = 0x1FF;  // Default value = all pins high
            uint gpiopinval = 0;

            res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, gpioDefVal, ref gpiopinval);
            if (res != E_SUCCESS)
            {
                Log_rtf.Text += "\nThere was an error in the Mcp2210_SetGpioPinVal function during SPI_disable_cs call";
                Log_rtf.Text += "\nThe error code is : ";
                Log_rtf.Text += res;
                // Handle the error
                return -1;
            }

            return 0;
        }

        private int ADC_scan_channels ()
        {
            int result;
            string txtbox_result;

            if (ADC_timer_flag == 1)
            {
                ADC_timer_flag = 0;            
                result = MCP3208_read_channel(ADC_actual_channel);
                if (result == -1) { return -1; }
                switch(ADC_actual_channel)
                {
                    case ADC_CH0:
                        struct_mcp3208.DUT_vin_monitor = Convert.ToUInt16(result);
                        ADC0_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString((result * ADC_v_p_lsb) / VIN_monitor_ratio);
                        ADC0_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH1:
                        struct_mcp3208.DUT_load_current_sense = Convert.ToUInt16(result);
                        ADC1_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(((result * ADC_v_p_lsb) / CURRENT_sense_resistor) * CURRENT_sense_gain);
                        ADC1_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH2:
                        struct_mcp3208.DUT_moisture_sense = Convert.ToUInt16(result);
                        ADC2_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(result * ADC_v_p_lsb);
                        ADC2_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH3:
                        struct_mcp3208.DUT_vfeedback_sense = Convert.ToUInt16(result);
                        ADC3_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(result * ADC_v_p_lsb);
                        ADC3_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH4:
                        struct_mcp3208.DUT_temperature_sense = Convert.ToUInt16(result);
                        ADC4_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(((result * ADC_v_p_lsb)-temp_offset)/temp_coeff);
                        ADC4_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH5:
                        struct_mcp3208.DUT_3V3_sense = Convert.ToUInt16(result);
                        ADC5_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(result * ADC_v_p_lsb);
                        ADC5_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH6:
                        struct_mcp3208.DUT_rtc_battery_sense = Convert.ToUInt16(result);
                        ADC6_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(result * ADC_v_p_lsb);
                        ADC6_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;

                    case ADC_CH7:
                        struct_mcp3208.DUT_light_sense = Convert.ToUInt16(result);
                        ADC7_raw_txtbox.Text = Convert.ToString(result);
                        txtbox_result = Convert.ToString(result * ADC_v_p_lsb);
                        ADC7_real_txtbox.Text = txtbox_result.Truncate(7);
                        break;
                }
                ADC_actual_channel += 1;
                if (ADC_actual_channel > 7) { ADC_actual_channel = 0; }
                return 0;
            }
            return 1;
        }

        private int RGBLED_set_color (byte color)
        {
            switch (color)
            {
                case RGBLED_RED:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_RED_ON);
                    break;

                case RGBLED_GREEN:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_GREEN_ON);
                    break;

                case RGBLED_BLUE:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_BLUE_ON);
                    break;

                case RGBLED_YELLOW:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_YELLOW_ON);
                    break;

                case RGBLED_WHITE:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_WHITE_ON);
                    break;

                case RGBLED_CYAN:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_CYAN_ON);
                    break;

                case RGBLED_PURPLE:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) & RGBLED_PURPLE_ON);
                    break;

                case RGBLED_OFF:
                    struct_mcp23s08.actual_port_output = Convert.ToByte((struct_mcp23s08.actual_port_output | 0xE0) | RGBLED_ALL_OFF);
                    break;
            }

            if (MCP23S08_write_byte(MCP23S08_ADR, OLAT, struct_mcp23s08.actual_port_output) == -1){ return -1; }

            return 0;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        // System level function - not related to any hardware access

        private void ADC_timer_Tick(object sender, EventArgs e)
        {
            ADC_timer_flag = 1;
        }



        private void Start_test_button_Click(object sender, EventArgs e)
        {
            Start_test_button.Enabled = false;
            Stop_test_button.Enabled = true;
            Main_timer.Enabled = true;
            state_machine = INITIALIZE_MCP2210;  // Initial state
        }

        private void Stop_test_button_Click(object sender, EventArgs e)
        {
            
            Start_test_button.Enabled = true;
            Stop_test_button.Enabled = false;
            state_machine = STOP_TEST;
        }

        private void RGBLED_blink_timer_Tick(object sender, EventArgs e)
        {
            if (RGBLED_blink_flag == 1)
            {
                RGBLED_blink_flag = 0;
                RGBLED_set_color(RGBLED_OFF);
            }
            else
            {
                RGBLED_blink_flag = 1;
                RGBLED_set_color(RGBLED_actual_color);
            }
        }

    }
}

public static class StringExt
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}