# Practical English Conversations - Software Guidebook

## Introduction

This software guidebook provides an overview of the **Practical English Conversations (PEC)** application. It includes a summary of the following:

- The requirements, constraints and principles behind the solution.
- The software architecture, including the high-level technology choices and structure of the software.
- The infrastructure architecture and how the software is deployed.
- Operational and support aspects of the application.

## Context

**PEC** es una herramienta para escuchar y practicar tu inglés a través conversaciones cortas.

### Users

1. Anonymous user

### External Systems

1. OpenAI API
2. Amazon Polly

## Functional Overview

### Generar conversación

```
Como usuario
Quiero generar conversaciones en inglés de un determinado tema
Para mis ejercicios de speaking

    1. Rule: Selección de tema específico
        a. Javier elige categoría 'Animals'
        b. Elige tema en forma de pregunta 'Are you afraid of any animals?'
        c. Solicita generación de conversación
        d. Conversación generada
    2. Rule: Conversación con 2 participantes
        a. Javier elige categoria 'Books'
        b. Elige tema 'When do you usually read?'
        c. Solicita generación de conversación
        d. Convesación generada con dos participantes 'Person 1' y 'Person 2'
```

### Reproducir conversación

```
Como usuario
Quiero convertir la conversación de texto a voz
Para escuchar la pronunciación de las palabras

https://cloud.google.com/text-to-speech
https://aws.amazon.com/polly/

```

### Reproducir conversación

## Quality Attributes

This section provides information about the desired quality attributes (non-functional requirements) of the application.

### Performance

All pages on PEC should load and render in under five seconds, for fifty concurrent users.

### Internationalisation

All user interface text will be presented in English only.

### Browser compatibility

The **PEC** should work consistently across the following browsers:

- Chrome
- Edge
- Firefox

## Constraints

This section provides information about the constraints imposed on the development of the **PEC** application.

### Budget

Since there is no formal budget for the **PEC**, there is a constraint to use free and open source technologies for the development. Ideally, the application should run on a single server with hosting costs of less than 20 USD per month.

## Principles

This section provides information about the principles adopted for the development of the **PEC** application.

### Automated testing

The strategy for automated testing is to use automated unit and component tests.

- **Unit tests:** These are fast running, very small tests that operate on a single class or method in isolation.
- **Component tests:** Rather than mocking out database connections to test component internals, components are tested as single units to avoid breaking encapsulation.

### Configuration

All configuration needed by components is externalised into a settings.json file, which is held outside of the deployment files created by the build process. This means that builds can be migrated from development, testing and into production without change.
