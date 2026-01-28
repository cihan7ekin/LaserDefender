# 🚀 Laser Defender: High-Performance Space Shooter

![Pattern](https://img.shields.io/badge/Pattern-Object%20Pooling-yellow)
![Architecture](https://img.shields.io/badge/Architecture-Component%20Based-orange)

> **Note:** This project is a technical demonstration of **Memory Management (Object Pooling)** and **Data-Driven Design** using Unity ScriptableObjects.

## 📖 Project Overview
Laser Defender is a top-down space shooter built to master Unity's 2D Physics engine and optimization techniques. The primary goal was to create a performant system capable of handling multiple on-screen entities without performance spikes (Garbage Collection), utilizing a strictly **Component-Based Architecture**.


## ⚙️ Key Technical Features

### 1. Object Pooling System (Optimization)
Instead of frequently using `Instantiate()` and `Destroy()` for projectiles—which causes CPU spikes—I implemented an **Object Pooling** pattern.
* **Mechanism:** Bullets and enemies are deactivated and returned to a pool rather than being destroyed, ensuring smooth 60 FPS gameplay on mobile devices.
* **Memory Safety:** Reduces Garbage Collection overhead significantly.

### 2. Data-Driven Enemy Waves (ScriptableObjects)
Implemented a flexible wave configuration system using **ScriptableObjects**.
* **Design Friendly:** Allows designers (or myself) to create complex enemy patterns (path, speed, count, enemy type) directly in the Inspector without touching the code.
* **Pathfinding:** Enemies follow defined waypoints using a modular pathfinding script.

```csharp
// Example: How Wave Configs separate data from logic
[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    
    public List<Transform> GetWaypoints() { ... }
}

### 3. Physics & Component-Based Architecture
Leveraged Unity's **Physics 2D engine** to handle interactions realistically.

* **Layer-Based Collision:** Configured strict **Collision Matrix** layers to prevent unnecessary physics checks (e.g., *Enemy lasers don't hit other enemies*).
* **Modular Components:** Achieved separation of concerns—`DamageDealer`, `Health`, and `Pathfinder` are separate scripts.
> This modularity allows creating new enemy variations simply by mixing and matching components.

## 🛠️ Tech Stack
* **Engine:** Unity 6 LTS
* **Language:** C#
* **Core Concepts:** `Coroutines`, `Quaternions`, Physics 2D (`Rigidbody2D` / `Colliders`)
* **Patterns:** Singleton (Audio/Score Managers), Object Pooling, Factory Method