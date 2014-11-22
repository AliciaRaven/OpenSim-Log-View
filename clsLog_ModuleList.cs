/*
 * Copyright (c) 2014 Spellscape Ltd
 * http://www.spellscape.co.uk
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLogView
{
    public enum Enum_ModuleCategory
    {
        mod_unknown = 0,
        mod_main = 1,
        mod_network = 2,
        mod_script = 3,
        mod_assets = 4,
        mod_ss_game = 5,
        mod_user_agents = 6,    // User Login and Movement
        mod_inventory = 7,      // User Inventory, Prim Inventory
        mod_grid = 8,
        mod_maps = 9,
        mod_archive = 10,
        mod_social = 11,        // Search, Groups, Events Etc
        mod_voice = 12,
        mod_notused = 13,
        mod_physics = 14,
        mod_environment = 15,
        mod_ss_region_man = 16,
        mod_ss_bank = 17,
        mod_ss_website = 18,
        mod_avatars = 19        // Xbakes, Attachments
    }

    public class clsLog_ModuleList
    {
        private Dictionary<string, Enum_ModuleCategory> arr_modules = new Dictionary<string, Enum_ModuleCategory>();

        // Constructor
        public clsLog_ModuleList()
        {
            // Modules Identified In Log As Being Between [] Characters

            // Add Names Of Sim Modules
            arr_modules.Add("XEngine", Enum_ModuleCategory.mod_script);
            arr_modules.Add("SCRIPT INSTANCE", Enum_ModuleCategory.mod_script);

            arr_modules.Add("OPENSIM MAIN", Enum_ModuleCategory.mod_main);
            arr_modules.Add("CONFIG", Enum_ModuleCategory.mod_main);
            arr_modules.Add("LOCAL CONSOLE", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SERVER BASE", Enum_ModuleCategory.mod_main);
            arr_modules.Add("PLUGINS", Enum_ModuleCategory.mod_main);
            arr_modules.Add("REGIONMODULES", Enum_ModuleCategory.mod_main);
            arr_modules.Add("LOAD REGIONS PLUGIN", Enum_ModuleCategory.mod_main);
            arr_modules.Add("REGION LOADER FILE SYSTEM", Enum_ModuleCategory.mod_main);
            arr_modules.Add("REGION INFO", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SCENE", Enum_ModuleCategory.mod_main);
            arr_modules.Add("MODULES", Enum_ModuleCategory.mod_main);
            arr_modules.Add("UTIL", Enum_ModuleCategory.mod_main);
            arr_modules.Add("MODULE COMMANDS", Enum_ModuleCategory.mod_main);
            arr_modules.Add("WATCHDOG", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SHUTDOWN", Enum_ModuleCategory.mod_main);
            arr_modules.Add("LOCAL SIMULATION CONNECTOR", Enum_ModuleCategory.mod_main);
            arr_modules.Add("REMOTE SIMULATION CONNECTOR", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SERVER", Enum_ModuleCategory.mod_main);
            arr_modules.Add("REGION DB", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SCENEGRAPH", Enum_ModuleCategory.mod_main);
            arr_modules.Add("SCENE OBJECT PART", Enum_ModuleCategory.mod_main);

            arr_modules.Add("CLIENTSTACK", Enum_ModuleCategory.mod_network);
            arr_modules.Add("REGION SERVER", Enum_ModuleCategory.mod_network);
            arr_modules.Add("BASE HTTP SERVER", Enum_ModuleCategory.mod_network);
            arr_modules.Add("LLUDPSERVER", Enum_ModuleCategory.mod_network);
            arr_modules.Add("LOGHTTP", Enum_ModuleCategory.mod_network);
            arr_modules.Add("FORMS", Enum_ModuleCategory.mod_network);

            arr_modules.Add("FLOTSAM ASSET CACHE", Enum_ModuleCategory.mod_assets);
            arr_modules.Add("HG ASSET SERVICE", Enum_ModuleCategory.mod_assets);
            arr_modules.Add("HG ASSET CONNECTOR", Enum_ModuleCategory.mod_assets);
            arr_modules.Add("ASSET CONNECTOR", Enum_ModuleCategory.mod_assets);
            arr_modules.Add("J2KDecoderModule", Enum_ModuleCategory.mod_assets);

            arr_modules.Add("LIBRARY INVENTORY", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("HG INVENTORY CONNECTOR", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("HG INVENTORY ACCESS MODULE", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("WEB FETCH INV DESC HANDLER", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("AGENT INVENTORY", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("PRIM INVENTORY", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("InventoryAccessModule", Enum_ModuleCategory.mod_inventory);
            arr_modules.Add("INVENTORY ACCESS MODULE", Enum_ModuleCategory.mod_inventory);

            arr_modules.Add("ATTACHMENTS MODULE", Enum_ModuleCategory.mod_avatars);
            arr_modules.Add("BAKES", Enum_ModuleCategory.mod_avatars);

            arr_modules.Add("LAND IN CONNECTOR", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("LAND CONNECTOR", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("NEIGHBOUR IN CONNECTOR", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("NEIGHBOUR CONNECTOR", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("SIM SERVICE", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("REMOTE GRID CONNECTOR", Enum_ModuleCategory.mod_grid);
            arr_modules.Add("HYPERGRID LINKER", Enum_ModuleCategory.mod_grid);

            arr_modules.Add("AUTH CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("AVATAR CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("REMOTE GRID USER CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("USER CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("SSDwell", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("BASE PRESENCE SERVICE CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("ENTITY TRANSFER MODULE", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("AUTHORIZATION CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("SCENE PRESENCE", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("CLIENT", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("REMOTE PRESENCE CONNECTOR", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("LLCLIENTVIEW", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("LLOGIN SERVICE", Enum_ModuleCategory.mod_user_agents);
            arr_modules.Add("GATEKEEPER SERVICE", Enum_ModuleCategory.mod_user_agents);

            arr_modules.Add("MAP IMAGE HANDLER", Enum_ModuleCategory.mod_maps);
            arr_modules.Add("MAP IMAGE SERVICE MODULE", Enum_ModuleCategory.mod_maps);
            arr_modules.Add("WORLD MAP", Enum_ModuleCategory.mod_maps);

            arr_modules.Add("Serialiser", Enum_ModuleCategory.mod_archive);
            arr_modules.Add("AUTO BACKUP", Enum_ModuleCategory.mod_archive);
            arr_modules.Add("ARCHIVER", Enum_ModuleCategory.mod_archive);
            arr_modules.Add("INVENTORY ARCHIVER", Enum_ModuleCategory.mod_archive);
            arr_modules.Add("SS IAR", Enum_ModuleCategory.mod_archive);

            arr_modules.Add("SEARCH", Enum_ModuleCategory.mod_social);
            arr_modules.Add("DATASNAPSHOT", Enum_ModuleCategory.mod_social);
            arr_modules.Add("Groups", Enum_ModuleCategory.mod_social);
            arr_modules.Add("Groups.Messaging", Enum_ModuleCategory.mod_social);
            arr_modules.Add("CHAT", Enum_ModuleCategory.mod_social);
            arr_modules.Add("EMAIL", Enum_ModuleCategory.mod_social);
            arr_modules.Add("PROFILES", Enum_ModuleCategory.mod_social);

            arr_modules.Add("Game", Enum_ModuleCategory.mod_ss_game);
            arr_modules.Add("BANK", Enum_ModuleCategory.mod_ss_bank);
            arr_modules.Add("Region Manager", Enum_ModuleCategory.mod_ss_region_man);
            arr_modules.Add("SSRegionManager", Enum_ModuleCategory.mod_ss_region_man);
            arr_modules.Add("WebUI", Enum_ModuleCategory.mod_ss_website);
            arr_modules.Add("WebTexture", Enum_ModuleCategory.mod_ss_website);

            arr_modules.Add("VivoxVoice", Enum_ModuleCategory.mod_voice);

            arr_modules.Add("RADMIN", Enum_ModuleCategory.mod_notused);

            arr_modules.Add("PHYSICS", Enum_ModuleCategory.mod_physics);
            arr_modules.Add("BULLETS SCENE", Enum_ModuleCategory.mod_physics);
            arr_modules.Add("EXTENDED PHYSICS", Enum_ModuleCategory.mod_physics);
            arr_modules.Add("BULLETSIM SHAPE", Enum_ModuleCategory.mod_physics);
            arr_modules.Add("BULLETS PRIM", Enum_ModuleCategory.mod_physics);

            arr_modules.Add("HEIGHTMAP TERRAIN DATA", Enum_ModuleCategory.mod_environment);
            arr_modules.Add("EnvironmentModule", Enum_ModuleCategory.mod_environment);
            arr_modules.Add("WIND", Enum_ModuleCategory.mod_environment);
            arr_modules.Add("REGION DB MYSQL", Enum_ModuleCategory.mod_environment);
        }

        public Enum_ModuleCategory GetModuleEnum(string strModule)
        {
            if (arr_modules.ContainsKey(strModule))
                return arr_modules[strModule];
            else
                return Enum_ModuleCategory.mod_unknown;
        }
    }
}
