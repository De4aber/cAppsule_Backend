pipeline {
    agent any

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
	
	    stage('Back-end tests') {
    		steps{
    		    dir ("BackendAPI/Core.Test/BackendTests") {
    		        sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
    		    }
    		}
        }
    }
}