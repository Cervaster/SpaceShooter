# 🚀 Space Shooter - 2D Arcade Game

![Unity](https://img.shields.io/badge/Engine-Unity-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-blue?style=for-the-badge&logo=csharp)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

A 2D arcade space shooter developed in **Unity** and **C#**, designed as a portfolio project focused on **gameplay programming**, software architecture in game development, and user interface design.

---

## 📸 Gameplay Preview

[![Play on Itch.io](https://img.shields.io/badge/PLAY_ON-ITCH.IO-FA5C5C?style=for-the-badge&logo=itchio&logoColor=white)](https://cerverus.itch.io/space-shooter)

---

## ✨ Key Features

* **2D Combat Mechanics:** Real-time ship control with continuous firing mechanics.
* **Enemy Patterns:** Scripted movement and behaviors for enemy ships.
* **HUD & UI System:** Real-time health (HP) and high score tracking.
* **Parallax Effect:** Layered space backdrop with dynamic scrolling for visual depth.
* **Audio Management:** Integrated ambient audio and background sound effects.
* **Pause Menu:** Interactive menu accessible via keypress or on-screen button.

---

## 🛠️ Technical Details & Implementation

* **Engine:** Unity (2D Pipeline)
* **Language:** C#
* **Architecture:**
  * Modular C# components ensuring clean separation of concerns (Player, Enemy, ScoreManager, UIManager).
  * 2D physics and collision handling using `Collider2D` and `Rigidbody2D`.
  * Optimized rendering for parallax scrolling backgrounds.

---

## 🎮 Controls

| Action | Key / Control |
| :--- | :--- |
| **Movement** | `W` `A` `S` `D` / Arrow keys |
| **Shoot** | `Space` |
| **Pause** | `P` / On-screen UI button |

---

## 📁 Project Structure

```text
Assets/
├── Scripts/        # C# Logic (Player, Enemy, UI, Managers)
├── Sprites/        # 2D Sprites for ships, projectiles, and backgrounds
├── Audio/          # Sound effects and ambient music
└── Scenes/         # Main level and menu scenes
