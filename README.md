# Practical English Conversations - Software Guidebook

## Introduction

This software guidebook provides an overview of the **Practical English Conversations (PEC)** website. It includes a summary of the following:

- The requirements, constraints and principles behind the solution.
- The software architecture, including the high-level technology choices and structure of the software.
- The infrastructure architecture and how the software is deployed.
- Operational and support aspects of the application.

URL: https://practical-conversations.azurewebsites.net/

## Context

**PEC** website is a tool for practicing English through short conversations. The application generates dialogues automatically using Artificial Intelligence (AI) based on different conversation topics. It can also convert text to spoken audio using natural AI voices to enhance the learning experience.

![](https://drive.google.com/uc?id=1okfJsxle5fxlpleZg81x_dR984MvEVrN)

### Users

1. **Anonymous user:** Anybody with a web browser can view conversations on the site.

### External Systems

1. **OpenAI API:** The OpenAI API can be applied to virtually any task that involves understanding or generating natural language, code, or images.
2. **Google Text-to-Speech:** Text-to-Speech allows developers to create natural-sounding, synthetic human speech as playable audio.

## Functional Overview

### Generar conversación

```
Como usuario
Quiero generar conversaciones en inglés de un determinado tema
Para mis ejercicios de listening/speaking

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

    1. Rule: Reprodución de audio individual de cada turno
        a. Generación de conversación con participantes 'Person 1' y 'Person 2'
        b. Reproducción audio de 'Person 1', turno 1
        c. Reproducción audio de 'Person 2', turno 1
        d. Reproducción audio de 'Person 1', turno 2
        e. Reproducción audio de 'Person 2', turno 2
    2. Rule: Diferentes voces en la conversación
        a. Generación de conversación con participantes 'Person 1' y 'Person 2'
        b. Reproducción de voz masculina para 'Person 1'
        c. Reproducción de voz femenina para 'Person 2'
```

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
- Safari

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

### Logging

- **Logging Framework for .NET:** NLog
- **Use an optimal structured log format:** By using a structured log with an optimal format, developers ensure that log data is readable, uniform, and easily searchable.

```
2023-03-07T12:15:30+00:00 [INFO] PaymentService - Payment processed successfully for Order #12345
```

- **Do NOT log sensitive information:** API keys, passwords, credentials and more fall under this category. It’s far to risky to log anything sensitive as it increases the chances of it leaking and becoming a security problem

```
❌
logger.error("Unable to log in", {request});

✅
logger.error("Unable to log in", {
  username: request.user,
  password: request.pass ? "[HIDDEN]" : null,
// any additional context needed?
})
```

- **Be specific in your messages:** Logging is only as beneficial as the message in the log, therefor, be specific.

```
❌
logger.info("We're starting!")
...
logger.info("task complete!")

✅
logger.info("Starting task", {
  name: taskName,
  params: params,
  startTime: startTime
});

logger.info("task complete", {
  response: output.response,
  event: {
    action: taskName,
    duration: currentTime - startTime
  }
})
```

- **Log all errors:** Logs are a best friend to those debugging, so, as a programmer if you find yourself in a situation writing error handling, make sure you always log the error before throwing a different one for the user. If we don’t log the original error then we could find ourselves with no context as too why we're throwing a `SystemError`.

```
catch(err)
{
    logger.error('An error occured', {error: err, args: args});
    throw new SystemError('Unable to process request');
}
```

### Dependency injection

## Software Architecture

This section provides an overview of the **PEC** software architecture.

![](https://drive.google.com/uc?id=1okIcOPlnTI9U9f-JOniSMSzDJxr0TWQK)

## Infrastructure Architecture

This section provides information about the infrastructure architecture of the **PEC**.

### Live environment

The live environment is very simple. We are going to use the following Azure Cloud Services:

- **Azure App Service**: Azure App Service is an HTTP-based service for hosting web applications, REST APIs, and mobile back ends.

## Deployment

This section provides information about the mapping between the **software architecture** and the **infrastructure architecture**. We use a deployment diagram to illustrate how instances of software systems and/or containers in the static model are deployed on to the infrastructure within a given **deployment environment** (e.g. production, staging, development, etc).

![](https://drive.google.com/uc?id=1olofdhS_S1JiJaP01DhclX2bOKI0x7SN)

## Links

- https://cloud.google.com/text-to-speech
- https://platform.openai.com
- https://portal.azure.com
