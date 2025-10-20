# Unity3D---Game-of-Life

Game of Life – Cellular Automaton Simulation

This project is an interactive simulation of Conway’s Game of Life, implemented in Unity 3D. The application visualizes the evolution of a cellular automaton based on simple mathematical rules that give rise to complex, lifelike behavior. The primary goal of this project was to explore procedural generation, simulation logic, and performance-conscious rendering within Unity’s 3D environment.

Concept Overview

The Game of Life, originally formulated by the British mathematician John Horton Conway in 1970, is a zero-player game in which the state of a two-dimensional grid evolves over time according to a set of deterministic rules. Each cell can be either alive or dead, and its state in the next generation is determined by the number of living neighbors:

A living cell with fewer than two live neighbors dies (underpopulation).

A living cell with two or three live neighbors survives.

A living cell with more than three live neighbors dies (overpopulation).

A dead cell with exactly three live neighbors becomes alive (reproduction).

Despite these simple rules, the system can produce extraordinarily complex and often unpredictable patterns that resemble biological growth, self-organization, and even computation.

Application Description

The Unity application automatically generates a custom grid based on the current window resolution. Each grid cell represents a 10×10 pixel area, allowing the board size to dynamically adjust to the user’s screen dimensions.

At runtime, the grid is populated with cells represented by 3D cubes, whose states are updated frame by frame according to Conway’s rules. The user can start or stop the simulation at any time, reset the grid, or generate a new board using one of two available generation modes:

Random Generation – fills the board with a random distribution of live and dead cells.

Symmetrical Generation – creates a balanced, mirrored layout to observe more structured evolution patterns.

The visualization updates in real time, providing immediate feedback on how small initial differences in configuration can lead to vastly different outcomes.

Key Features

Dynamic board generation based on display resolution (10 px per grid cell)

Start, stop, and reset functionality for full control over simulation flow

Two distinct generation modes: random and symmetrical

Optimized update cycles for efficient real-time rendering

Modular code structure suitable for further algorithmic experimentation

Technical Summary

Engine: Unity 3D

Language: C#

Rendering: Real-time procedural mesh updates

Primary Focus: Algorithm simulation, procedural content generation, and state management

Educational Purpose

This project demonstrates the emergent behavior of simple rule-based systems and serves as an educational tool for understanding cellular automata, simulation design, and algorithmic visualization in a 3D engine environment. It can also serve as a basis for further exploration of generative systems, artificial life, and computational modeling.
