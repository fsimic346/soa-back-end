package model

type KeyPointSecret struct {
	Images      []string `json:"images" default:"null"`
	Description string   `json:"description"`
}