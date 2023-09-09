#include "pch.h"
#include <string>
#include <vector>
#include <cmath>
#include <iostream>
#include <random>
#include <windows.h>

// Define the ResourceNode struct
struct ResourceNode {
    std::string type;
    float x, y, z; // 3D position in the game world
};

// Define the Player struct
struct Player {
    float x, y, z; // 3D position in the game world
};

// Function to calculate the distance between a player and a node
float CalculateDistance(const Player& player, const ResourceNode& node) {
    return static_cast<float>(std::sqrt(std::pow(player.x - node.x, 2) +
        std::pow(player.y - node.y, 2) +
        std::pow(player.z - node.z, 2)));
}

ResourceNode FindNearestNode(const Player& player, const std::vector<ResourceNode>& nodes) {
    if(nodes.empty()) {
        throw std::runtime_error("No nodes provided to search for the nearest one.");
    }

    ResourceNode nearestNode = nodes[0];
    float shortestDistance = CalculateDistance(player, nearestNode); 

    for(size_t i = 1; i < nodes.size(); i++) {
        float currentDistance = CalculateDistance(player, nodes[i]);
        if(currentDistance < shortestDistance) {
            shortestDistance = currentDistance;
            nearestNode = nodes[i];
        }
    }

    return nearestNode;
}

std::vector<ResourceNode> TrackResourceNodes() {
    std::vector<ResourceNode> nodes;
    std::random_device rd;
    std::mt19937 gen(rd());
    std::uniform_real_distribution<> dis(-100.0, 100.0);

    Player player = ReadPlayerPositionFromMemory();

    for(int i = 0; i < 10; i++) {
        nodes.push_back({"Crimsonite", player.x + dis(gen), player.y + dis(gen), player.z + dis(gen)});
    }

    return nodes;
}

void DrawDistanceBox(const std::wstring& text) {
    std::wcout << text << std::endl;
}

Player ReadPlayerPositionFromMemory() {
    Player player = {}; 
    uintptr_t playerPositionAddress = 0xYourPlayerPositionMemoryAddress;
    ReadProcessMemory(GetCurrentProcess(), (LPCVOID)playerPositionAddress, &player, sizeof(Player), nullptr);
    return player;
}

ResourceNode ReadCrimsoniteVeinFromMemory() {
    ResourceNode crimsoniteVein = {};
    uintptr_t crimsoniteVeinAddress = 0x2C64048D368;
    ReadProcessMemory(GetCurrentProcess(), (LPCVOID)crimsoniteVeinAddress, &crimsoniteVein, sizeof(ResourceNode), nullptr);
    return crimsoniteVein;
}

void UpdateResourceTracker() {
    Player player = ReadPlayerPositionFromMemory();
    std::vector<ResourceNode> nodes = TrackResourceNodes();
    ResourceNode nearestNode = FindNearestNode(player, nodes);
    float distance = CalculateDistance(player, nearestNode);

    std::wstring crimsoniteText = L"Distance to nearest Crimsonite Vein: " + std::to_wstring(distance) + L" units";
    DrawDistanceBox(crimsoniteText);
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
