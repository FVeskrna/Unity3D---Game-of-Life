# Game of Life – Cellular Automaton Simulation

This project is an interactive simulation of **Conway’s Game of Life**, developed in **Unity 3D**.  
It visualizes the evolution of a cellular automaton governed by simple deterministic rules that, when applied iteratively, produce complex and emergent behavior.  
The project serves as a demonstration of procedural generation, simulation logic, and efficient state management within a real-time 3D engine.

---

## Overview

The **Game of Life**, proposed by mathematician **John Horton Conway** in 1970, is a zero-player game in which the evolution of a two-dimensional grid is determined entirely by its initial state.  
Each cell in the grid can exist in one of two states: *alive* or *dead*. With each generation, the following transition rules are applied:

1. Any live cell with fewer than two live neighbors dies (underpopulation).  
2. Any live cell with two or three live neighbors survives.  
3. Any live cell with more than three live neighbors dies (overpopulation).  
4. Any dead cell with exactly three live neighbors becomes a live cell (reproduction).  

Despite their simplicity, these rules can lead to complex patterns such as oscillators, gliders, and self-replicating systems, illustrating the principles of emergent behavior.

---

## Application Description

The application dynamically generates a simulation grid based on the current window resolution.  
Each grid cell corresponds to a 10×10 pixel area, ensuring that the total board size adapts to any screen dimension.

Cells are represented as 3D cubes whose states update in real time according to Conway’s rules.  
Users can interact with the simulation through a simple user interface that provides full control over the simulation lifecycle.

### Core Functionality

- **Dynamic grid generation** – the grid scales automatically based on screen resolution (10 pixels per cell).  
- **Simulation control** – start, stop, and reset the simulation at any time.  
- **Two generation modes**:  
  - *Random mode* – randomly populates the board with live and dead cells.  
  - *Symmetrical mode* – generates a mirrored initial state to observe more structured evolution.  
- **Responsive visualization** – updates occur in real time for smooth pattern transitions.  
- **Optimized performance** – efficient handling of grid updates even for large board sizes.

---

## Technical Summary

- **Engine:** Unity 3D  
- **Programming Language:** C#  
- **Rendering:** Real-time procedural mesh updates  
- **Primary Focus:** Cellular automata, algorithm simulation, procedural generation, and optimization of state transitions  

---

## Educational Purpose

This project serves as a visual and conceptual exploration of how simple rule-based systems can give rise to complex behavior.  
It provides an accessible platform for studying **cellular automata**, **emergent phenomena**, and **algorithmic modeling**.  
In addition to its educational purpose, it offers a foundation for further experimentation in generative systems, artificial life, or computational simulation within Unity.

---

## Future Extensions

- Implementation of color-based visual states to represent cell age or energy  
- Introduction of custom rule sets beyond the standard Conway model  
- 3D cellular automata with volumetric evolution  
- Pattern import/export functionality for well-known Life configurations  

---

## License

This project is released for educational and non-commercial use.
