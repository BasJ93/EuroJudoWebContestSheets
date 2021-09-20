pipeline {
    agent any
    stages {
        stage('Docker build') {
            environment {
                NUGET_CREDS = credentials('NuGet')
            }
            steps {
                sh "docker build -t ejuweb . --build-arg NUGET_USR=$NUGET_CREDS_USR --build-arg NUGET_PW=$NUGET_USR_PSW"
            }
        }
        stage('Restart container') {
            steps {
                sh "docker restart ejuweb"
            }
        }
    }
}