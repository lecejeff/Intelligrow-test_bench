
using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
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

        // set the SPI xfer params for I/O expander
        uint usb_spi_baudrate = 1000000;                    // mbps
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

        struct SPI_DAC_MCP4922
        {
            public UInt16 DAC_outa;
            public UInt16 DAC_outb;
        }
        SPI_DAC_MCP4922 struct_mcp4922;
        public const byte DAC_OUTA = 0;
        public const byte DAC_OUTB = 1;

        // IO Expander structure and register definition --------------------------------
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
            public byte EXP_light_ctrl_in;
            public byte EXP_pump_ctrl_in;
            public byte EXP_light_gate_in;
            public byte EXP_pump_gate_in;
            public byte EXP_DUT_enable;
            public byte EXP_rgbled_r;
            public byte EXP_rgbled_g;
            public byte EXP_rgbled_b;
            public byte default_port_output;
            public byte default_port_mapping;
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
        //-------------------------------------------------------------------------------
        public const byte MCP2210_default_io_config = 0x040;

        // ------------------------------------------------------------------------------
        // Application-related variables
        public byte ADC_timer_flag = 0;
        public byte ADC_actual_channel = 0;




        // Variables de test
        UInt16 DAC_data = 0;
        public Form1()
        {
            InitializeComponent();

            MCP2210_connect_btn.Enabled = true;
            MCP2210_disconnect_btn.Enabled = false;

            struct_mcp23s08.default_port_output = 0xEF;
            struct_mcp23s08.default_port_mapping = 0x0F;
            struct_mcp4922.DAC_outa = 0x000;
            struct_mcp4922.DAC_outb = 0x000;

            DUT_enable_btn.Enabled = false;
            DUT_disable_btn.Enabled = false;
            ADC_timer.Enabled = false;
        }

        private void MCP2210_connect_btn_Click(object sender, EventArgs e)
        {
            int devCount = Mcp2210_GetConnectedDevCount(DEFAULT_VID, DEFAULT_PID);
            Console.WriteLine(devCount);
            if (devCount > 0)   // Check wether there is a MCP2210 connected or not
            {
                // Get the device handle before intializing the device with the default configuration
                MCP2210_deviceHandle = Mcp2210_OpenByIndex(DEFAULT_VID, DEFAULT_PID, 0, path, ref pathSize); //try to open the first device
                res = Mcp2210_GetLastError();
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("Could not open the connection to the MCP2210. Verify it is properly plugged in the USB port.");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }
                Console.WriteLine("MCP2210 successfully opened");

                res = Mcp2210_SetGpioPinDir(MCP2210_deviceHandle, MCP2210_default_io_config);
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("There was an error in the Mcp2210_SetGpioPinDir function");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }

                uint gpiopinval = 0x01A8;
                res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, 0x01FF, ref gpiopinval);
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("There was an error in the Mcp2210_SetGpioPinVal function");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }

                res = Mcp2210_SetGpioConfig(MCP2210_deviceHandle, MCP2210_VM_CONFIG, gpioPinDes, 1, 0, MCP2210_REMOTE_WAKEUP_DISABLED, MCP2210_INT_MD_CNT_NONE, MCP2210_SPI_BUS_RELEASE_DISABLED);
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("There was an error in the Mcp2210_SetGpioConfig function");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }

                res = Mcp2210_SetSpiConfig(MCP2210_deviceHandle, MCP2210_VM_CONFIG, ref usb_spi_baudrate, ref usb_spi_idle_cs, ref usb_spi_active_cs, ref usb_spi_cs2data_delay, ref usb_spi_data2data_delay, ref usb_spi_data2cs_delay,
                    ref usb_spi_txfer_size, ref usb_spi_mode);
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("There was an error in the Mcp2210_SetSpiConfig function");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }

                MCP23S08_write_byte(MCP23S08_ADR, IODIR, struct_mcp23s08.default_port_mapping);
                MCP23S08_write_byte(MCP23S08_ADR, OLAT, struct_mcp23s08.default_port_output);

                Console.WriteLine("MCP2210 successfully configured");
                ADC_timer.Enabled = true;
                device_opened = 1;
                MCP2210_connect_btn.Enabled = false;
                MCP2210_disconnect_btn.Enabled = true;
                DUT_enable_btn.Enabled = true;
            }

            else
            {
                Console.WriteLine("No MCP2210 device found");
            }
        }

        private void MCP2210_disconnect_btn_Click(object sender, EventArgs e)
        {
            res = Mcp2210_Close(MCP2210_deviceHandle);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_Close function");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return;
            }

            Console.WriteLine("MCP2210 successfully closed");
            device_opened = 0;
            ADC_timer.Enabled = false;

            MCP2210_connect_btn.Enabled = true;
            MCP2210_disconnect_btn.Enabled = false;
            DUT_disable_btn.Enabled = false;
            DUT_enable_btn.Enabled = false;
        }

        private void DUT_enable_btn_Click(object sender, EventArgs e)
        {
            if (device_opened == 1)
            {
                MCP23S08_write_byte(MCP23S08_ADR, OLAT, 0xBF);
                DUT_enable_btn.Enabled = false;
                DUT_disable_btn.Enabled = true;
            }
        }

        private void DUT_disable_btn_Click(object sender, EventArgs e)
        {
            if (device_opened == 1)
            {
                MCP23S08_write_byte(MCP23S08_ADR, OLAT, 0xEF);
                DUT_enable_btn.Enabled = true;
                DUT_disable_btn.Enabled = false;
            }
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
                MCP23S08_write_byte(MCP23S08_ADR, OLAT, 0xEF);
                res = Mcp2210_Close(MCP2210_deviceHandle);
                if (res != E_SUCCESS)
                {
                    Console.WriteLine("There was an error in the Mcp2210_Close function");
                    Console.WriteLine(" The error code is : ");
                    Console.WriteLine(res);
                    // Handle the error
                    return;
                }
                e.Cancel = false;            
            }
        }


        private Int16 MCP23S08_read_byte(byte address, byte register)
        {
            uint spi_txfer_size = 3;
            byte read_address = Convert.ToByte(address | 0x01);
            byte[] MCP23S08_io_value = { read_address, register, 0};
            byte[] MCP23S08_rx_data = { 0, 0, 0 };
            SPI_enable_cs(MCP23S08);
            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP23S08_io_value, MCP23S08_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_xferSpiData function while setting the output values of the IO expander");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return -1;
            }
            SPI_disable_cs(MCP23S08);
            return MCP23S08_rx_data[2]; // Return the value of the requested register
        }

        private void MCP23S08_write_byte (byte address, byte register, byte value)
        {
            uint spi_txfer_size = 3;
            byte[] MCP23S08_io_value = { address, register, value };
            byte[] MCP23S08_rx_data = { 0, 0, 0 };
            SPI_enable_cs(MCP23S08);
            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP23S08_io_value, MCP23S08_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_xferSpiData function while setting the output values of the IO expander");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return;
            }
            SPI_disable_cs(MCP23S08);
        }

        private void MCP4922_write_output (byte channel, UInt16 value)
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
            SPI_enable_cs(MCP4922);
            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP4922_io_value, MCP4922_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_xferSpiData function while setting the output values of the DAC");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return;
            }
            SPI_disable_cs(MCP4922);
        }

        private UInt16 MCP3208_read_channel (byte channel)
        {
            uint spi_txfer_size = 3;
            byte tx_data_0 = Convert.ToByte(0x06 | ((channel & 0x04) >> 2));
            byte tx_data_1 = Convert.ToByte((channel & 0x03) << 6);
            byte[] MCP3208_io_value = { tx_data_0, tx_data_1, 0xFF};
            byte[] MCP3208_rx_data = { 0, 0 , 0};

            SPI_enable_cs(MCP3208);
            res = Mcp2210_xferSpiData(MCP2210_deviceHandle, MCP3208_io_value, MCP3208_rx_data, ref usb_spi_baudrate, ref spi_txfer_size, MCP2210_GP8CE_MASK);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_xferSpiData function while setting the channel of the ADC");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
            }
            SPI_disable_cs(MCP3208);
            UInt16 output_word = Convert.ToUInt16(((MCP3208_rx_data[1] << 8) | MCP3208_rx_data[2])&0x0FFF);
            return output_word;
        }

        //--------------------------------------------------------------------//
        // SPI #CS workaround to prevent GPIO toggling / changing state during
        // actual SPI transfers
        private void SPI_enable_cs(uint device)
        {
            uint gpioDefVal = 0x1FF;  // Default value = all pins high
            uint gpiopinval = 0;

            gpioDefVal = gpioDefVal & device;

            res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, gpioDefVal, ref gpiopinval);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_SetGpioPinVal function during SPI_enable_cs call");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return;
            }
        }

        private void SPI_disable_cs(uint device)
        {
            uint gpioDefVal = 0x1FF;  // Default value = all pins high
            uint gpiopinval = 0;

            res = Mcp2210_SetGpioPinVal(MCP2210_deviceHandle, gpioDefVal, ref gpiopinval);
            if (res != E_SUCCESS)
            {
                Console.WriteLine("There was an error in the Mcp2210_SetGpioPinVal function during SPI_disable_cs call");
                Console.WriteLine(" The error code is : ");
                Console.WriteLine(res);
                // Handle the error
                return;
            }
        }

        private void ADC_scan_channels ()
        {
            UInt16 result;
            if (ADC_timer_flag == 1)
            {

                MCP4922_write_output(DAC_OUTA, DAC_data);

                ADC_timer_flag = 0;
                result = MCP3208_read_channel(ADC_actual_channel);
                switch(ADC_actual_channel)
                {
                    case ADC_CH0:
                        struct_mcp3208.DUT_vin_monitor = result;
                        ADC0_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH1:
                        struct_mcp3208.DUT_load_current_sense = result;
                        ADC1_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH2:
                        struct_mcp3208.DUT_moisture_sense = result;
                        ADC2_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH3:
                        struct_mcp3208.DUT_vfeedback_sense = result;
                        ADC3_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH4:
                        struct_mcp3208.DUT_temperature_sense = result;
                        ADC4_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH5:
                        struct_mcp3208.DUT_3V3_sense = result;
                        ADC5_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH6:
                        struct_mcp3208.DUT_rtc_battery_sense = result;
                        ADC6_txtbox.Text = Convert.ToString(result);
                        break;

                    case ADC_CH7:
                        struct_mcp3208.DUT_light_sense = result;
                        ADC7_txtbox.Text = Convert.ToString(result);
                        break;
                }
                ADC_actual_channel += 1;
                if (ADC_actual_channel > 7) { ADC_actual_channel = 0; }

            }
        }

        private void RGBLED_set_color (byte color)
        {

        }

        private void ADC_timer_Tick(object sender, EventArgs e)
        {
            ADC_timer_flag = 1;
            DAC_data = Convert.ToUInt16(DAC_data + 25);
            if (DAC_data > 0xFFF) { DAC_data = 0; }
        }

        private void Main_timer_Tick(object sender, EventArgs e)
        {
            ADC_scan_channels();
        }
    }
}
