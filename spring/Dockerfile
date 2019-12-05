
FROM maven:3.5.2-jdk-8-alpine AS MAVEN_BUILD

COPY pom.xml /build/
COPY src /build/src/
WORKDIR /build/
RUN mvn package -P prod

FROM openjdk:8-jre-alpine
WORKDIR /app
COPY --from=MAVEN_BUILD /build/target/api-0.0.1-SNAPSHOT.jar /app/
ENTRYPOINT ["java","-Dspring.profiles.active=prod ", "-jar", "api-0.0.1-SNAPSHOT.jar"]


#RUN
# docker run -p 8080:8080 spring
#build
# docker build -t  spring . 


# FROM openjdk:8-jdk-alpine
# WORKDIR /usr/app

# COPY ./target/api-0.0.1-SNAPSHOT.jar ./
# WORKDIR /usr/app
# ENTRYPOINT ["java","-jar","api-0.0.1-SNAPSHOT.jar"]



